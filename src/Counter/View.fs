module Counter.View

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types

let simpleButton txt action dispatch =
    div
      [ ClassName "column is-narrow" ]
      [ a
          [ ClassName "button"
            OnClick (fun _ -> action |> dispatch) ]
          [ str txt ] ]

let root model dispatch =
    div
        [ ClassName "columns is-vcentered" ]
        [ div
            [ ClassName "column is-half is-offset-one-quarter"
              Style
                [ CSSProp.Width "170px" ] ]
            [ str (sprintf "Counter value: %i" model) ]
          simpleButton "inc" Increment dispatch
          simpleButton "dec" Decrement dispatch
          simpleButton "Reset" Reset dispatch ]
