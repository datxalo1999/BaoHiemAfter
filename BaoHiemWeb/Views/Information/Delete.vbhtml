@ModelType BaoHiemWeb.Information
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Information</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.TenKhachHang)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TenKhachHang)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CreateDay)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CreateDay)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LoaiBaoHiem.LoaiBaoHiem1)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LoaiBaoHiem.LoaiBaoHiem1)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
