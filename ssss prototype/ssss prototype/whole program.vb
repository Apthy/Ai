Imports System.Math
Imports System
Imports System.Random
Imports System.Numerics
Imports System.Object
Module Module1


    Sub Main()
        Dim input As String
        input = Console.ReadLine
        Dim splitstore(input.Length + 1) As String
        Dim temp As String
        For i = 0 To (input.Length - 1)
            temp = (Asc(input.Substring(i, 1)))
            If temp.Length < 3 Then
                temp = "0" & Asc(input.Substring(i, 1))
                'this is the part that takes the ascii values however not all of the values are 3 digits so this would make the whole decryption more complex so to simplify it i have added a 0 to the begining
                'once the lagrange interpolation is complete at a later stage it will remove the extra 0 if needed
            End If
            splitstore(i) = temp
            temp = ""
            Console.WriteLine("position " & i & " is " & (splitstore(i)))
        Next
        'this concatanates all if the values into a string to then be put into a big integer.
        'otherwise id just be adding the values wich is no use


        Dim bigNumStore As String = ""
        'this is needed as i cant add the text of 2 integers
        Dim bignum As BigInteger
        For i = 0 To input.Length
            bigNumStore = bigNumStore & splitstore(i)
            bignum = bigNumStore
            Console.WriteLine("the ascii phrase numerically is currently " & bigNumStore)
        Next

        ssssEncry(bigNumStore)
        ssssDecrypt()
        Console.ReadLine()
    End Sub
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

        Dim y() As BigInteger
        Dim ENDSUM As Double
        'this maybe a doubble i dunno do some research on this

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

    End Function
End Module
