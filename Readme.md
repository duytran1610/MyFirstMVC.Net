## Controller
- Là một lớp kế thừa từ lớp Controller: Microsoft.AspNetCore.Mvc.Controller
- Action in controller là 1 method public (không đc static)
- Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào controller qua hàm tạo
## View
- Là file .cshtml
- View cho Action lưu tại: /View/Controller/Action.cshtml
- Thêm thư mục lưu trữ View:
```
// {0} -> ten Action
// {1} -> ten Controller
// {2} -> ten Area
options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
```
## Truyền dữ liệu sang View
- Model
- ViewData
- ViewBag
- TempData