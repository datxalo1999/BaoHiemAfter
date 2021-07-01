@ModelType BaoHiemWeb.Information
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
