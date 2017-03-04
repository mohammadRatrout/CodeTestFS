//Step 1,Step2,Step3,Step4,Step5,Step6
open System// to use String.Join


let cutting (str:string) = //major cange as this function help to minimize change area
    match str with
    |str when str.StartsWith("//[")->
     let delimeter=str.[3..str.IndexOf("]") - 1]
     ([|delimeter|],str.[str.IndexOf("\n")..])//return them as both delimetrs and the string that contain the numbers
    |str when str.StartsWith("//")->
     let delimeter=str.[2]
     ([|string delimeter|],str.[3..])//return them as both delimetrs and the string that contain the numbers

    |str ->([|",";"\n"|],str)
let Add input =
    match input with
       |"" -> 0
       |input ->let delimeter, str= cutting input
                let neg, pos = str.Split(delimeter, StringSplitOptions.RemoveEmptyEntries) |> Array.map int |> Array.partition(fun n->n<0)
                if neg.Length>0 then
                invalidArg "input" (sprintf "the numbers are %s"<| String.Join(",",neg))
                else
                pos|>Array.filter(fun n-> n<1000)|>Array.sum                                        


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
let resultofMultibleDelimeters = Add "//[***]\n 3***4***5"