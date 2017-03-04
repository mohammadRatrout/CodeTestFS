//Step 1,Step2,Step3,Step4,Step5
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
                pos|>Array.sum
       |input->  
                let neg, pos = input.Split(',','\n') |> Array.map int |> Array.partition(fun n->n<0)
                if neg.Length>0 then
                invalidArg "input" (sprintf "the numbers are %s"<| String.Join(",",neg))//if there is negatives we do this
                else
                pos|>Array.sum   //else print them as usaual                                         

let resultOfEmpty= Add ""
let resultOfTwoOrMore = Add "1,2,4,5" 
let resultOfNewLine=Add "1\n2,3"
let resultOfNewLine2=Add "1,2\n3"//handling more opperands gave me the power of doing this
                                 //in java i only allowed for two opperands and because of this  
                                 //new line were only allowed before the delimeter
let resultOfDefinedDelimeter =Add "//;\n1;2"
let resultOfDefinedDelimeter2 =Add "//#4\n#2#5"
let resultOfNegatives = Add "//# 1#-2#-3"