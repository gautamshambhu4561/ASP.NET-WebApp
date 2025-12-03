using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LMSProject.App_Code
{
    public class DBHelper
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["LMSDB"].ConnectionString;

        public static bool RegisterUser(string name, string email, string password, string role)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "INSERT INTO Users (Name, Email, PasswordHash, Role) VALUES (@Name, @Email, @PasswordHash, @Role)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PasswordHash", HashPassword(password));
                        cmd.Parameters.AddWithValue("@Role", role);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidateUser(string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "SELECT UserID, Name, Role, PasswordHash FROM Users WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["PasswordHash"].ToString();
                                if (VerifyPassword(password, storedHash))
                                {
                                    HttpContext.Current.Session["UserID"] = reader["UserID"].ToString();
                                    HttpContext.Current.Session["UserName"] = reader["Name"].ToString();
                                    HttpContext.Current.Session["UserRole"] = reader["Role"].ToString();
                                    return true;
                                }
                            }
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }

        private static bool VerifyPassword(string password, string storedHash)
        {
            return HashPassword(password) == storedHash;
        }

        public static DataTable GetCourses()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT CourseID, Title, Description, InstructorID FROM Courses";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetInstructorCourses(int instructorId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT CourseID, Title FROM Courses WHERE InstructorID = @InstructorID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@InstructorID", instructorId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static bool EnrollUser(int userId, int courseId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "INSERT INTO Enrollments (UserID, CourseID) VALUES (@UserID, @CourseID)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@CourseID", courseId);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DataTable GetCourseMaterials(int courseId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT MaterialID, Title, FilePath FROM Materials WHERE CourseID = @CourseID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static DataTable GetCourseAssignments(int courseId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT AssignmentID, Title, DueDate FROM Assignments WHERE CourseID = @CourseID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static DataTable GetCourseAnnouncements(int courseId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT AnnouncementID, Title, Content, PostedDate FROM Announcements WHERE CourseID = @CourseID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static DataTable GetEnrolledStudents(int courseId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT u.UserID, u.Name, u.Email FROM Users u JOIN Enrollments e ON u.UserID = e.UserID WHERE e.CourseID = @CourseID AND u.Role = 'Student'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CourseID", courseId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public static bool CreateCourse(string title, string description, int instructorId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "INSERT INTO Courses (Title, Description, InstructorID) VALUES (@Title, @Description, @InstructorID)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@InstructorID", instructorId);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UploadMaterial(int courseId, string title, string filePath)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "INSERT INTO Materials (CourseID, Title, FilePath) VALUES (@CourseID, @Title, @FilePath)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CourseID", courseId);
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@FilePath", filePath);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool SubmitAssignment(int assignmentId, int userId, string filePath)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "INSERT INTO Submissions (AssignmentID, UserID, FilePath) VALUES (@AssignmentID, @UserID, @FilePath)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AssignmentID", assignmentId);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@FilePath", filePath);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateGrade(int submissionId, int grade)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "UPDATE Submissions SET Grade = @Grade WHERE SubmissionID = @SubmissionID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Grade", grade);
                        cmd.Parameters.AddWithValue("@SubmissionID", submissionId);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DataTable GetUserSubmissions(int userId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT s.SubmissionID, a.AssignmentID, a.Title, s.Grade FROM Submissions s JOIN Assignments a ON s.AssignmentID = a.AssignmentID WHERE s.UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}