//Step 1

let Add input =
    match input with
       |"" -> 0
       |input-> input.Split(',') |> Array.map int |> Array.sum // first splitting the string it gave a character array 
                                                              //in which we turn it to int then calculate the sum


let resultOfEmpty= Add ""
let result = Add "1,2" 