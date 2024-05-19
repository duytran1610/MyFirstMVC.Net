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

## Areas
- Là tên dùng để routing
- Là cấu trúc thư mục chứa M.V.C
- Thiết lập Area cho controller bằng ```[Area("AreaName")]```
- Tạo cấu trúc thư mục
```
dotnet aspnet-codegenerator area AreaName
```

## Route
- MapControllerRoute
- MapAreaControllerRoute
- [AcceptVerbs("POST", "GET")]
- [Route("pattern")]
- [HttpGet] [HttpPost]

## Url Generation
### UrlHelper: Action, ActionLink, RouteUrl, Link
```
Url.Action("PlanetInfo","Planet",new {id=1}, Context.Request.Scheme)

Url.RouteUrl("default", new {controller="First", action="HelloView", id=1, username="Hello"})
```
### HtmlTaghelper: ```<a> <button> <form>```
Sử dụng thuộc tính:
```
asp-area="Area"
asp-aciton="Action"
asp-controller="Product"
asp-route...="123"
asp-route="default"
```