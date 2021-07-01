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
    Public Class LoaiBaoHiemsController
        Inherits System.Web.Mvc.Controller

        Private db As New DBBaoHiemEntities

        ' GET: LoaiBaoHiems
        Function Index() As ActionResult
            Return View(db.LoaiBaoHiems.ToList())
        End Function

        ' GET: LoaiBaoHiems/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim loaiBaoHiem As LoaiBaoHiem = db.LoaiBaoHiems.Find(id)
            If IsNothing(loaiBaoHiem) Then
                Return HttpNotFound()
            End If
            Return View(loaiBaoHiem)
        End Function

        ' GET: LoaiBaoHiems/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: LoaiBaoHiems/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,LoaiBaoHiem1")> ByVal loaiBaoHiem As LoaiBaoHiem) As ActionResult
            If ModelState.IsValid Then
                db.LoaiBaoHiems.Add(loaiBaoHiem)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(loaiBaoHiem)
        End Function

        ' GET: LoaiBaoHiems/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim loaiBaoHiem As LoaiBaoHiem = db.LoaiBaoHiems.Find(id)
            If IsNothing(loaiBaoHiem) Then
                Return HttpNotFound()
            End If
            Return View(loaiBaoHiem)
        End Function

        ' POST: LoaiBaoHiems/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,LoaiBaoHiem1")> ByVal loaiBaoHiem As LoaiBaoHiem) As ActionResult
            If ModelState.IsValid Then
                db.Entry(loaiBaoHiem).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(loaiBaoHiem)
        End Function

        ' GET: LoaiBaoHiems/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim loaiBaoHiem As LoaiBaoHiem = db.LoaiBaoHiems.Find(id)
            If IsNothing(loaiBaoHiem) Then
                Return HttpNotFound()
            End If
            Return View(loaiBaoHiem)
        End Function

        ' POST: LoaiBaoHiems/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim loaiBaoHiem As LoaiBaoHiem = db.LoaiBaoHiems.Find(id)
            db.LoaiBaoHiems.Remove(loaiBaoHiem)
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
