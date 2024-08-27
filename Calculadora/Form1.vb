Public Class Form1
    ' Variables para almacenar los números y la operación seleccionada.
    Private currentNumber As String = ""
    Private firstNumber As Decimal = 0
    Private operation As String = ""

    ' Evento para los botones numéricos (0-9).
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Dim button As Button = CType(sender, Button)
        currentNumber &= button.Text
        txtDisplay.Text = currentNumber
    End Sub

    ' Evento para los botones de operación (+, -, *, /).
    Private Sub Operation_Click(sender As Object, e As EventArgs) Handles btnSumar.Click, btnRestar.Click, btnMultiplicación.Click, btnDivisión.Click
        Dim button As Button = CType(sender, Button)
        If currentNumber <> "" Then
            firstNumber = Decimal.Parse(currentNumber)
            currentNumber = ""
            operation = button.Text
        End If
    End Sub

    ' Evento para el botón "=".
    Private Sub btnResultado_Click(sender As Object, e As EventArgs) Handles btnResultado.Click
        Dim secondNumber As Decimal
        Dim result As Decimal

        If currentNumber <> "" Then
            secondNumber = Decimal.Parse(currentNumber)
            Select Case operation
                Case "+"
                    result = firstNumber + secondNumber
                Case "-"
                    result = firstNumber - secondNumber
                Case "x"
                    result = firstNumber * secondNumber
                Case "/"
                    ' Manejar la división por cero.
                    If secondNumber <> 0 Then
                        result = firstNumber / secondNumber
                    Else
                        MessageBox.Show("No se puede dividir por cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Case Else
                    result = 0
            End Select

            txtDisplay.Text = result.ToString()
            currentNumber = result.ToString()
            operation = ""
        End If
    End Sub

    ' Evento para el botón "C" que limpia el display y resetea la calculadora.
    Private Sub BtnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        txtDisplay.Clear()
        currentNumber = ""
        firstNumber = 0
        operation = ""
    End Sub

    ' Configura el formulario para que no se pueda redimensionar.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
    End Sub
End Class

