module App.Types

type Page =
    | Home
    | Counter
    | CounterList
    | About
    | Cmdd

let toHash page =
    match page with
    | About -> "#about"
    | Counter _ -> "#counter"
    | CounterList _ -> "#counterlist"
    | Home _ -> "#home"
    | Cmdd _ -> "#cmdd"


type Msg =
    | CounterMsg of Counter.Types.Msg
    | CounterListMsg of CounterList.Types.Msg
    | HomeMsg of Home.Types.Msg
    | CmddMsg of Cmdd.Msg

type Model =
    { CurrentPage : Page
      Counter : Counter.Types.Model
      CounterList : CounterList.Types.Model
      Home: Home.Types.Model
      Cmdd: Cmdd.Model }
