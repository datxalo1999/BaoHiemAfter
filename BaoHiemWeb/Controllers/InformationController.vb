Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports BaoHiemWeb

Namespace Controllers
    Public Class InformationController
        Inherits System.Web.Mvc.Controller

        Private db As New DBBaoHiemEntities


        ' GET: Information
        'Function Index() As ActionResult
        '    Dim information = db.Information.Include(Function(i) i.LoaiBaoHiem)
        '    Return View(information.ToList())
        'End Function
        Function Index(ByVal InsurranceType As String, ByVal searchString As String) As ActionResult
            Dim TypeList As New List(Of String)
            Dim TypeQuery = From m In db.LoaiBaoHiems
                            Order By m.LoaiBaoHiem1
                            Select m.LoaiBaoHiem1

            TypeList.AddRange(TypeQuery.Distinct)

            ViewBag.InsurranceType = New SelectList(TypeList) 'chuyen du lieu tu controller sang view
            Dim informations = From m In db.Information Select m
            If Not String.IsNullOrEmpty(searchString) Then
                informations = informations.Where(Function(m) m.TenKhachHang.Contains(searchString) Or m.Address.Contains(searchString))
            End If
            'If Not String.IsNullOrEmpty(InsurranceType) Then
            '    informations = informations.Where(Function(m) m.LoaiBaoHiem.Equals(InsurranceType))
            'End If
            Return View(informations)
        End Function

        ' GET: Information/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim information As Information = db.Information.Find(id)
            If IsNothing(information) Then
                Return HttpNotFound()
            End If
            Return View(information)
        End Function

        ' GET: Information/Create
        Function Create() As ActionResult
            ViewBag.idLoaiBaoHiem = New SelectList(db.LoaiBaoHiems, "id", "LoaiBaoHiem1")
            Return View()
        End Function

        ' POST: Information/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,TenKhachHang,idLoaiBaoHiem,CreateDay,Address")> ByVal information As Information) As ActionResult
            If ModelState.IsValid Then
                db.Information.Add(information)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.idLoaiBaoHiem = New SelectList(db.LoaiBaoHiems, "id", "LoaiBaoHiem1", information.idLoaiBaoHiem)
            Return View(information)
        End Function

        ' GET: Information/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim information As Information = db.Information.Find(id)
            If IsNothing(information) Then
                Return HttpNotFound()
            End If
            ViewBag.idLoaiBaoHiem = New SelectList(db.LoaiBaoHiems, "id", "LoaiBaoHiem1", information.idLoaiBaoHiem)
            Return View(information)
        End Function

        ' POST: Information/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,TenKhachHang,idLoaiBaoHiem,CreateDay,Address")> ByVal information As Information) As ActionResult
            If ModelState.IsValid Then
                db.Entry(information).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.idLoaiBaoHiem = New SelectList(db.LoaiBaoHiems, "id", "LoaiBaoHiem1", information.idLoaiBaoHiem)
            Return View(information)
        End Function

        ' GET: Information/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim information As Information = db.Information.Find(id)
            If IsNothing(information) Then
                Return HttpNotFound()
            End If
            Return View(information)
        End Function

        ' POST: Information/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim information As Information = db.Information.Find(id)
            db.Information.Remove(information)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
