module Cmdd
open Fable.Helpers.React
open Fable.Helpers.React.Props

type Msg =
  | Increment
  | Decrement
  | Reset

type Model = int

let init () = 0

let update (msg:Msg) (model:Model) : Model =
  match msg with
  | Increment -> model + 1
  | Decrement -> model - 1
  | Reset -> 0

let simpleButton txt action dispatch =
    div
      [ ClassName "column is-narrow" ]
      [ a
          [ ClassName "button"
            OnClick (fun _ -> action |> dispatch) ]
          [ str txt ] ]

let view model dispatch =
    div
        [ ClassName "columns is-vcentered" ]
        [ div
            [ ClassName "column is-half is-offset-one-quarter"
              Style
                [ CSSProp.Width "170px" ] ]
            [ str (sprintf "Counter value: %i" model) ]
          simpleButton "increment" Increment dispatch
          simpleButton "reset" Reset dispatch
          simpleButton "decrement" Decrement dispatch]
