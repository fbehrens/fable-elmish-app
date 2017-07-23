module Fea

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser

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
   |> JQuery.css "background-color" "green"
   |> JQuery.click (fun ev -> console.log("Clicked"))
   |> JQuery.addClass "fancy-class"
   |> ignore
)

console.log("hi")
