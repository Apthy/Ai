Imports System.Math
Imports System.Numerics
'this is the function im using to take the points from the line
Module Module2
    Function ssssDecrypt()
        Dim x() As Integer

        Dim y() As BigInteger
        Dim ENDSUM As Integer
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
