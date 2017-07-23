module Fea

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System

[<Emit("undefined")>]
let undefined : obj = jsNative
// console.log(undefined) // undefined

[<Emit("1")>]
let one : int = jsNative
//console.log(one + one) // 2

[<Emit("$0 === undefined")>]
let isUndefined (x: 'a) : bool = jsNative
// console.log(isUndefined 5) // false
// console.log(isUndefined "") // false
// console.log(isUndefined [||]) // false
// console.log(isUndefined (undefined)) // true

[<Emit("isNaN($0)")>]
let isNaN (x: 'a) = jsNative
// console.log(isNaN (log -2.0)) // true

[<Emit("Math.random()")>]
let getRandom() : float = jsNative
// console.log(getRandom())

// Option<'t>
[<Emit("isNaN(parseFloat($0)) ? null : parseFloat($0)  ")>]
let parseFloat (input : string) : float option = jsNative

let testParseFloat s =
  match parseFloat s with
    | Some value -> console.log(value)
    | None -> console.log("parseFloat failed!")
// testParseFloat "3,14"
// testParseFloat "%"


JQuery.ready (fun () ->
   JQuery.select "#main"
   //|> JQuery.css "background-color" "green"
   |> JQuery.click (fun ev -> console.log("Clicked"))
   |> JQuery.addClass "fancy-class"
   |> ignore
)

// Oject
[<StringEnum>]
type TimeUnit =
  | Days
  | Months
  | Years

type IAddTimeProps =
  abstract Current : DateTime with get, set
  abstract Amount : int with get, set
  abstract Unit : TimeUnit with get, set

let parameter = createEmpty<IAddTimeProps>
parameter.Current <- DateTime.Now
parameter.Amount <- 20
parameter.Unit <- TimeUnit.Days
//console.log(parameter)


// Using [<Pojo>] Attribute
[<Pojo>]
type Person = {
  name : string
  age  : int
}
let person = { name = "Mike"; age = 35 }
let me = { person with name = "Zaid" }
let stillMe = { me with age = 20 }
// console.log(stillMe) // { name: "Zaid", age: 20 }


//Using a list of discriminated union as object literal
type Person1 =
  | Name of string
  | Age of int
let person1 = [ Name "Mike"; Age 35 ]


// Creating object literals inline
let literalObject =
  createObj [
    "prop" ==> "value"
    "anotherProp" ==> 5
  ]
//console.log(literalObject) // { prop: "value", "anotherProp": 5 }


// Interacting with existing Javascript code
let tryParseJson : string -> obj option = import "parseJson" "./custom.js"
let tryGetValue : obj -> string -> obj option = import "getValue" "./custom.js"


let parseJson json =
    match tryParseJson json with
        | Some o1 -> o1
        | None -> failwithf "Json parsing did not succeed"
let getValue o k =
    match tryGetValue o k with
        | Some v -> v
        | None -> failwithf "Object did not have key %s" k

let json = "{ \"name\": \"Frank\", \"age\": 25 }"
let me1 = parseJson json
console.log(me1)
console.log( getValue me "age"  )


// match getValue objLiteral "SpecialProp" with
// | Some result -> console.log(result) // the value is defined, log it
// | None -> console.log("No such property was found")





console.log("hi")
