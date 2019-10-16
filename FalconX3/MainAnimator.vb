﻿Imports System.Runtime.InteropServices
Imports FalconX3.VisualEffects
Imports FalconX3.VisualEffects.Animations.Effects
Imports FalconX3.VisualEffects.Easing

Public Class MainAnimator

    Public IsMoving As Boolean = False
    Dim POS As Integer = 0

    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal wMsg As Int32, ByVal wParam As Boolean, ByVal lParam As Int32) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInt32) As Boolean
    End Function

    Private Sub Panel1_Move(sender As Object, e As EventArgs) Handles Panel1.Move
        SendMessage(FalconX.ReBarWindow32Ptr, FalconX.WM_SETREDRAW, True, 0)

        Dim position = Panel1.Left

        If FalconX.Horizontal = False Then
            SetWindowPos(FalconX.MSTaskListWClassPtr, IntPtr.Zero, 0, position, 0, 0, FalconX.SWP_NOZORDER Or FalconX.SWP_NOSIZE Or FalconX.SWP_ASYNCWINDOWPOS Or FalconX.SWP_NOSENDCHANGING Or FalconX.SWP_NOACTIVATE)
        Else
            SetWindowPos(FalconX.MSTaskListWClassPtr, IntPtr.Zero, position, 0, 0, 0, FalconX.SWP_NOSIZE Or FalconX.SWP_ASYNCWINDOWPOS Or FalconX.SWP_NOACTIVATE)
        End If

        SendMessage(FalconX.ReBarWindow32Ptr, FalconX.WM_SETREDRAW, False, 0)
    End Sub

    Dim SPEED As Integer = 0
    Dim EFFECT As String = "None"

    Dim OldPos As Integer = 0

    Sub AnimatorMove()

        POS = FalconX.TaskbarNewPos

        SPEED = CInt(FalconX.NumericUpDown1.Value)

        EFFECT = FalconX.ComboBox1.Text

        If POS = OldPos + 1 Then
            EFFECT = "Linear"
        End If

        If POS = OldPos Then
            EFFECT = "Linear"
        End If

        If POS = OldPos - 1 Then
            EFFECT = "Linear"
        End If

        OldPos = POS

        Dim t1 As System.Threading.Thread = New System.Threading.Thread(AddressOf Go)
        t1.Start()

    End Sub

    Sub Go()

        Dim CurrentProcess As Process = Process.GetCurrentProcess
        CurrentProcess.PriorityClass = ProcessPriorityClass.High

        Do Until IsMoving = False
            System.Threading.Thread.Sleep(10) : Application.DoEvents()
        Loop

        IsMoving = True

        If EFFECT = "" Then
            Panel1.Left = POS
            IsMoving = False

            CurrentProcess.PriorityClass = ProcessPriorityClass.Normal
        End If

        If EFFECT = "None" Then
            Panel1.Left = POS
            IsMoving = False

            CurrentProcess.PriorityClass = ProcessPriorityClass.Normal
        End If

        If EFFECT = "Linear" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.Linear, POS, SPEED, 0)
        End If

        If EFFECT = "ExpoEaseOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.ExpoEaseOut, POS, SPEED, 0)
        End If

        If EFFECT = "ExpoEaseIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.ExpoEaseIn, POS, SPEED, 0)
        End If

        If EFFECT = "ExpoEaseInOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.ExpoEaseInOut, POS, SPEED, 0)
        End If

        If EFFECT = "ExpoEaseOutIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.ExpoEaseOutIn, POS, SPEED, 0)
        End If

        If EFFECT = "CircEaseOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.CircEaseOut, POS, SPEED, 0)
        End If

        If EFFECT = "CircEaseIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.CircEaseIn, POS, SPEED, 0)
        End If

        If EFFECT = "CircEaseInOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.CircEaseInOut, POS, SPEED, 0)
        End If

        If EFFECT = "CircEaseOutIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.CircEaseOutIn, POS, SPEED, 0)
        End If

        If EFFECT = "QuadEaseOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.QuadEaseOut, POS, SPEED, 0)
        End If

        If EFFECT = "QuadEaseIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.QuadEaseIn, POS, SPEED, 0)
        End If

        If EFFECT = "QuadEaseInOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.QuadEaseInOut, POS, SPEED, 0)
        End If

        If EFFECT = "QuadEaseOutIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.QuadEaseOutIn, POS, SPEED, 0)
        End If

        If EFFECT = "SineEaseOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.SineEaseOut, POS, SPEED, 0)
        End If

        If EFFECT = "SineEaseIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.SineEaseIn, POS, SPEED, 0)
        End If

        If EFFECT = "SineEaseInOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.SineEaseInOut, POS, SPEED, 0)
        End If

        If EFFECT = "SineEaseOutIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.SineEaseOutIn, POS, SPEED, 0)
        End If

        If EFFECT = "CubicEaseOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.CubicEaseOut, POS, SPEED, 0)
        End If

        If EFFECT = "CubicEaseIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.CubicEaseIn, POS, SPEED, 0)
        End If

        If EFFECT = "CubicEaseInOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.CubicEaseInOut, POS, SPEED, 0)
        End If

        If EFFECT = "CubicEaseOutIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.CubicEaseOutIn, POS, SPEED, 0)
        End If

        If EFFECT = "QuartEaseOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.QuartEaseOut, POS, SPEED, 0)
        End If

        If EFFECT = "QuartEaseIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.QuartEaseIn, POS, SPEED, 0)
        End If

        If EFFECT = "QuartEaseInOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.QuartEaseInOut, POS, SPEED, 0)
        End If

        If EFFECT = "QuartEaseOutIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.QuartEaseOutIn, POS, SPEED, 0)
        End If

        If EFFECT = "QuintEaseOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.QuintEaseOut, POS, SPEED, 0)
        End If

        If EFFECT = "QuintEaseIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.QuintEaseIn, POS, SPEED, 0)
        End If

        If EFFECT = "QuintEaseInOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.QuintEaseInOut, POS, SPEED, 0)
        End If

        If EFFECT = "QuintEaseOutIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.QuintEaseOutIn, POS, SPEED, 0)
        End If

        If EFFECT = "ElasticEaseOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.ElasticEaseOut, POS, SPEED, 0)
        End If

        If EFFECT = "ElasticEaseIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.ElasticEaseIn, POS, SPEED, 0)
        End If

        If EFFECT = "ElasticEaseInOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.ElasticEaseInOut, POS, SPEED, 0)
        End If

        If EFFECT = "ElasticEaseOutIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.ElasticEaseOutIn, POS, SPEED, 0)
        End If

        If EFFECT = "BounceEaseOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.BounceEaseOut, POS, SPEED, 0)
        End If

        If EFFECT = "BounceEaseIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.BounceEaseIn, POS, SPEED, 0)
        End If

        If EFFECT = "BounceEaseInOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.BounceEaseInOut, POS, SPEED, 0)
        End If

        If EFFECT = "BounceEaseOutIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.BounceEaseOutIn, POS, SPEED, 0)
        End If

        If EFFECT = "BackEaseOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.BackEaseOut, POS, SPEED, 0)
        End If

        If EFFECT = "BackEaseIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.BackEaseIn, POS, SPEED, 0)
        End If

        If EFFECT = "BackEaseInOut" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.BackEaseInOut, POS, SPEED, 0)
        End If

        If EFFECT = "BackEaseOutIn" Then
            Panel1.Animate(New XLocationEffect(), AddressOf EasingFunctions.BackEaseOutIn, POS, SPEED, 0)
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Console.WriteLine("form2")
        AddHandler Animator.Animated, AddressOf IsAnimated
    End Sub

    Sub IsAnimated()
        IsMoving = False
        FalconX.SaveMemory()
        Dim CurrentProcess As Process = Process.GetCurrentProcess
        CurrentProcess.PriorityClass = ProcessPriorityClass.Normal
    End Sub

End Class