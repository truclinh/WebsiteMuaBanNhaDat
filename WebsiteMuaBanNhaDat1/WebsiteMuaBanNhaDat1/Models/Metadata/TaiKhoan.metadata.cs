using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebsiteMuaBanNhaDat1.Models
{
    [MetadataType(typeof(TaiKhoanMetadata))]
    public partial class TaiKhoan
    {
        internal sealed class TaiKhoanMetadata
        {
            public int? ma_taikhoan { get; set; }
            [Display(Name = "Tên đăng nhập")]
            [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
            public string tendangnhap { get; set; }
            [Display(Name = "Mật khẩu")]
           // [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 ký tự.")]
           [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
            public string matkhau { get; set; }
            [Display(Name = "Xác nhận mật khẩu")]
            [Compare("matkhau", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
            public string xacnhan_matkhau { get; set; }
            [Display(Name = "Tên người dùng")]
           [Required(ErrorMessage = "Yêu cầu nhập tên người dùng")]
            public string tennguoidung { get; set; }
            [Display(Name = "Địa chỉ")]
            public string diachi { get; set; }
            [Display(Name = "Email")]
            public string email { get; set; }
            [Display(Name = "Điện thoại")]
            public string dienthoai { get; set; }
            public string ghichu { get; set; }
            [Display(Name = "Ảnh đại diện")]
            public string anhdaidien { get; set; }
        }
    }
}