namespace HUPR.Core

open System

[<AutoOpen>]
module Domain =
    [<Measure>] type dupr

    module DUPR =
        type Id = internal Id of string
        type DuprId = internal DuprId of string


    module Match =
        type Id = internal Id of uint
        type MatchId = internal MatchId of uint
        type UserId = internal UserId of uint
        type DisplayIdentity = internal DisplayIdentity of string

        module Player =
            type Rating =
                internal
                | Singles of float<dupr>
                | Doubles of float<dupr>

            type RatingImpact =
                internal
                | Singles of float<dupr>
                | Doubles of float<dupr>

        type Player = {
            Id: DUPR.Id
            DuprId: DUPR.DuprId
            Name: string
            PostMatchRating: Player.Rating
        }

        module Team =
            type Id = internal Id of uint

            type PreMatchRatingAndImpact = {
                Player1: {|
                    PreMatchRating: Player.Rating
                    RatingImpact: Player.RatingImpact
                |}
                Player2: {|
                    PreMatchRating: Player.Rating
                    RatingImpact: Player.RatingImpact
                |} option
            }

        type Team = {
            Id: Team.Id
            Player1: Player
            Player2: Player option
            Score: uint
            IsWinner: bool
        }

    type Match = {
        Id: Match.Id
        MatchId: Match.MatchId
        UserId: Match.UserId
        DisplayIdentity: Match.DisplayIdentity
        EventDate: DateTime
        Location: string
        Venue: string
        Team1: Match.Team
        Team2: Match.Team
        Created: DateTime
        Modified: DateTime
    }