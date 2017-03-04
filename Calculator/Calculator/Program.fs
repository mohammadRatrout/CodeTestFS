//Step 1,Step2,Step3,Step4,Step5,Step6
open System// to use String.Join
let Add input =
    match input with
       |"" -> 0
       |input when input.StartsWith("//")->
                let delimeter=input.[2] 
                let neg, pos = input.[3..].Split(delimeter) |> Array.map int |> Array.partition(fun n->n<0)
                if neg.Length>0 then
                invalidArg "input" (sprintf "the numbers are %s"<| String.Join(",",neg))
                else
                pos|>Array.filter(fun n->n < 1000)|>Array.sum 
       |input->  
                let neg, pos = input.Split(',','\n') |> Array.map int |> Array.partition(fun n->n<0)
                if neg.Length>0 then
                invalidArg "input" (sprintf "the numbers are %s"<| String.Join(",",neg))//if there is negatives we do this
                else
                pos|>Array.filter(fun n->n < 1000)|>Array.sum   //else print them as usaual                                         


                /////tetsting
let resultOfEmpty= Add ""// return 0
let resultOfTwoOrMore = Add "1,2,4,5" //return 12
let resultOfNewLine=Add "1\n2,3"// return 6
let resultOfNewLine2=Add "1,2\n3"//handling more opperands gave me the power of doing this
                                 //in java i only allowed for two opperands and because of this  
                                 //new line were only allowed before the delimeter
                                 //return 6
let resultOfDefinedDelimeter =Add "//;\n1;2"//return 3
let resultOfDefinedDelimeter2 =Add "//#4\n#2#5"//return 11
//let resultOfNegatives = Add "//# 1#-2#-3" //commetted so it dont throw exception 
let resultOfMoreThanThousend= Add "1,2,1004"// return 3
let resultOfMoreThanThousend2= Add "//^1^1002"//return 1