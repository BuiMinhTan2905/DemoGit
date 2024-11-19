using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace project_1.Controllers
{
    public class StudentController : Controller
    {
        // Danh sách lưu thông tin sinh viên đã đăng ký
        private static List<StudentModel> RegisteredStudents = new List<StudentModel>();

        // GET: Trang nhập thông tin sinh viên
        public IActionResult Index()
        {
            return View();
        }

        // POST: Xử lý đăng ký và hiển thị kết quả
        [HttpPost]
        public IActionResult ShowKQ(StudentModel student)
        {
            // Thêm sinh viên vào danh sách
            RegisteredStudents.Add(student);

            // Đếm số lượng sinh viên đã đăng ký cùng ngành
            int sameMajorCount = RegisteredStudents.FindAll(s => s.ChuyenNganh == student.ChuyenNganh).Count;

            // Truyền thông tin kết quả vào ViewBag
            ViewBag.MSSV = student.MSSV;
            ViewBag.HoTen = student.HoTen;
            ViewBag.ChuyenNganh = student.ChuyenNganh;
            ViewBag.SameMajorCount = sameMajorCount;

            return View();
        }
    }

    // Model để lưu thông tin sinh viên
    public class StudentModel
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public double DiemTB { get; set; }
        public string ChuyenNganh { get; set; }
    }
}
