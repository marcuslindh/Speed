Imports System.Threading.Tasks
Imports System.Threading
Imports System.Windows.Forms

Public Class MultiThreading
    Private this As Form

    Public Thread As task

    Public Sub New(form As Form)
        this = form
    End Sub

    Public Sub Run(ByVal func As Action)
        Thread = Task.Factory.StartNew(func)
    End Sub



    'Public Sub RunWithCancellationToken(fun As Action, CancellationToken As CancellationToken)
    '    Thread = Task.Factory.StartNew(fun, CancellationToken)
    'End Sub


    'Public Sub Run(ByVal fun As Action, Completion As Action)
    '    Thread = Task.Factory.StartNew(fun)



    '    Dim CheckStatus As Task = Task.Factory.StartNew(Sub()
    '                                                        While True
    '                                                            If Not Thread.Status = TaskStatus.Running Then
    '                                                                ThreadSafe("", Sub(n)
    '                                                                                   Completion()
    '                                                                               End Sub)
    '                                                                Exit While
    '                                                            End If

    '                                                        End While
    '                                                    End Sub)

    'End Sub

    Public Sub ThreadSafe(ByVal data As Object, ByVal func As Action(Of Object))
        If this.InvokeRequired Then
            Dim d As New DelegateGetData(AddressOf ThreadSafe)
            Try
                this.Invoke(d, New Object() {data, func})
            Catch ex As Exception

            End Try
        Else
            func(data)
        End If
    End Sub

    Private Delegate Sub DelegateGetData(ByVal data As Object, ByVal func As Action(Of Object))

End Class
