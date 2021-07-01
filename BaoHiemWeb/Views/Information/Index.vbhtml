@ModelType IEnumerable(Of BaoHiemWeb.Information)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>THÔNG TIN BẢO HIỂM</h2>

<p>
    @Html.ActionLink("Thêm mới", "Create")

    @Using Html.BeginForm("Index", "Information", FormMethod.Get)

    @<p> Loại bảo hiểm @Html.DropDownList("InsurranceType", "All")</p>
    @<p>
        @Html.TextBox("SearchString")
    <input type="submit" value="Tìm kiếm" /
</p>
    End Using
    </p>
    <table class="table">
        <tr>
            <th>
                Tên khách hàng
                @*@Html.DisplayNameFor(Function(model) model.TenKhachHang)*@
            </th>
            <th>
                Ngày tạo
                @*@Html.DisplayNameFor(Function(model) model.CreateDay)*@
            </th>
            <th>
                Địa chỉ
                @*@Html.DisplayNameFor(Function(model) model.Address)*@
            </th>
            <th>
                Loại bảo hiểm
                @*@Html.DisplayNameFor(Function(model) model.LoaiBaoHiem.LoaiBaoHiem1)*@
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.TenKhachHang)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.CreateDay)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Address)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.LoaiBaoHiem.LoaiBaoHiem1)
                </td>
                <td>
                    @Html.ActionLink("Sửa", "Edit", New With {.id = item.Id}) |
                    @Html.ActionLink("Chi tiết", "Details", New With {.id = item.Id}) |
                    @Html.ActionLink("Xoá", "Delete", New With {.id = item.Id})
                </td>
            </tr>
        Next

    </table>
