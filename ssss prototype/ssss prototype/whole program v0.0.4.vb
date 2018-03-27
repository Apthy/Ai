Imports System.Math
Imports System
Imports System.Random
Imports System.Numerics
Imports System.Object
Module Module1


    Sub Main()
        Dim input As String
        Dim bigNumStore As String = ""
        Console.WriteLine("ye, so this is broke af")
        Console.WriteLine("please enter command")
        input = Console.ReadLine
        If input = "en" Then
            Console.WriteLine("type your text you want to encrypt")
            IOvalue(bigNumStore)
            ssssEncry(bigNumStore)
        ElseIf input = "de" Then
            ssssDecrypt()
        Else
            Console.WriteLine("error")
        End If
        Console.ReadLine()
    End Sub
    Function IOvalue(ByRef bignumstore)
        Dim secretTxt As String
        secretTxt = Console.ReadLine
        Dim splitstore(secretTxt.Length + 1) As String
        Dim temp As String
        For i = 0 To (secretTxt.Length - 1)
            temp = (Asc(secretTxt.Substring(i, 1)))
            If temp.Length < 3 Then
                temp = "0" & Asc(secretTxt.Substring(i, 1))
                'this is the part that takes the ascii values however not all of the values are 3 digits so this would make the whole decryption more complex so to simplify it i have added a 0 to the begining
                'once the lagrange interpolation is complete at a later stage it will remove the extra 0 if needed
            End If
            splitstore(i) = temp
            temp = ""
            Console.WriteLine("position " & i & " is " & (splitstore(i)))
        Next
        'this concatanates all if the values into a string to then be put into a big integer.
        'otherwise id just be adding the values wich is no use

        'this is needed as i cant add the text of 2 integers
        Dim bignum As BigInteger
        For i = 0 To secretTxt.Length - 1
            bignumstore = bignumstore & splitstore(i)
            Console.WriteLine("the ascii phrase numerically is currently " & bignumstore)
        Next

        bignum = Val(bignumstore)
        Return bigNumStore
    End Function
    Function ssssEncry(ByVal bignumstore As String)
        Console.WriteLine("how many parts do you want to split it into?")
        Dim parts As Integer = Console.ReadLine
        Console.WriteLine("how many shares do you want for it to be retrievable(the more the more secure)")
        Dim RtrableParts As Integer = Console.ReadLine
        Dim getRndm As Random = New Random
        Dim polyno(RtrableParts - 1) As Integer
        Dim x As String

        For z = 0 To RtrableParts - 1
            Randomize()
            polyno(z) = getRndm.Next(1, 99) '{REMEMBER TO PUT THIS BACK UP TO 9999999}

        Next
        Dim fx As BigInteger

        'this calculates the values of the points you want used in shamirs secret sharing
        For i = 0 To parts - 1 'edit here becasue x changes each loop you need to put in a nested for loop REPLACE"POLYNO" WITH "DESCRIMINANT"

            fx = bignumstore
            x = getRndm.Next(1, 9) '{REMEMBER TO PUT THIS BACK UP TO 999}
            For z = 0 To RtrableParts - 1
                fx = fx + ((x ^ (z + 1)) * (polyno(z))) 'this was wrong you needed to put it to the power of i

            Next
            ' Console.Write("x= " & x & "y= ")
            ' Console.WriteLine(fx)
            Console.Write("SHARE ")
            Console.Write((i + 1) & "     " & x & ",")
            Console.WriteLine(fx)
            fx = 0
        Next
    End Function
    'GET THE RANDOM NUMBERS WORKING ON THIS LAST BIT DOING THE POLYNOMIALS

    Function ssssDecrypt()
        Dim x() As Integer

        Dim y() As Decimal
        Dim ENDSUM As Decimal
        'research as doccumented said decimal is the best type

        Dim z As Integer
        ENDSUM = 0
        Console.WriteLine("how many parts are needed to be rertievable?")
        Dim rtrbleparts As Integer = Console.ReadLine
        ReDim x(rtrbleparts - 1)
        ReDim y(rtrbleparts - 1)
        For i = 0 To rtrbleparts - 1
            Console.WriteLine("parts needed" & rtrbleparts - i)
            Console.Write("x=")
            x(i) = Console.ReadLine
            Console.Write("Y=")
            y(i) = Console.ReadLine

        Next

        Dim numerator As Integer = 1
        Dim denominator As Integer = 1


        For i = 0 To rtrbleparts - 1
            For z = 0 To rtrbleparts - 1
                If z <> i Then
                    numerator = numerator * (-1) * x(z)
                End If
                'this is for the numerator it has a check for all values if it is the same
            Next
            For c = 0 To rtrbleparts - 1
                If c <> i Then
                    denominator = denominator * (x(i) - x(c))

                End If

            Next
            ENDSUM = ENDSUM + (y(i) * (numerator / denominator))
            denominator = 1
            numerator = 1
            Console.WriteLine(ENDSUM)

        Next
        Console.WriteLine("therefore your key is " & Round(ENDSUM))
        Dim secretnum As String = Round(ENDSUM)

        chrValue(secretnum)

    End Function

    Function chrValue(ByVal secretnum)
        Dim secretTxt As String
        Dim secretchr As String = ""
        secretnum = (Console.ReadLine)
        For i = 0 To (secretnum.Length / 3) - 1


            secretchr = secretnum.Substring(3 * i, 3)
            If secretchr.Substring(0, 1) = 0 Then
                secretchr = secretchr.Substring(1, 2)
            End If

            Console.WriteLine(secretchr)

            secretTxt = secretTxt & Chr(secretchr)
            Console.WriteLine(secretTxt)
        Next
        Console.ReadLine()

    End Function


    Private Function Convert(p1 As Object) As Integer
        Throw New NotImplementedException
    End Function

End Module
