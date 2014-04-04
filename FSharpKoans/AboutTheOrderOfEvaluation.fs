namespace FSharpKoans
open FSharpKoans.Core

//---------------------------------------------------------------
// About the Order of Evaluation
//
// Sometimes you'll need to be explicit about the order in which
// functions are evaluated. F# offers a couple mechanisms for
// doing this.
//---------------------------------------------------------------
[<Koan(Sort = 4)>]
module ``about the order of evaluation`` =

    [<Koan>]
    let SometimesYouNeedParenthesisToGroupThings() =
        let add x y =
            x + y

        let result = add (add 5 8) (add 1 1)
        //let result = add <| add 5 8 <| add 1 1

        AssertEquality result 15

        (* TRY IT: What happens if you remove the parensthesis?*)
        (* You get 3 compiler errors...
        Error	1	The type 'int -> 'a -> int -> int -> 'b' does not match the type 'int'	Line 17	Column 15
        Error	2	Type mismatch. Expecting a 'a but given a 'a -> 'b -> 'c -> 'd -> 'e -> 'f -> 'g 
                    The resulting type would be infinite when unifying ''a' and ''a -> 'b -> 'c -> 'd -> 'e -> 'f -> 'g' Line 19 Column 26
        Error	3	Type mismatch. Expecting a 'a but given a 'b -> int -> int -> 'a -> 'c -> 'd -> 'e
                    The resulting type would be infinite when unifying ''a' and ''b -> int -> int -> 'a -> 'c -> 'd -> 'e' Line 19 Column 34
        I obviously need some practice interpreting F# compiler errors! *)

    [<Koan>]
    let TheBackwardPipeOperatorCanAlsoHelpWithGrouping() =
        let add x y =
            x + y

        let double x =
            x * 2

        //let result = double <| add 5 8
        let result = double (add 5 8)

        AssertEquality result 26
