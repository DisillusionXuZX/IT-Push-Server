open Suave
open Suave.Http
open Suave.Operators
open Suave.Filters
open Suave.Successful
open Suave.Files
open Suave.RequestErrors
open Suave.Logging
open Suave.Utils

open System
open System.Net

open Suave.Sockets
open Suave.Sockets.Control
open Suave.WebSocket



let app : Suave.Http.WebPart =
    Suave.WebPart.choose [
        Suave.Filters.GET >=> Suave.WebPart.choose [
            Suave.Filters.pathScan "/%s" Suave.Files.file ]
        Suave.RequestErrors.NOT_FOUND "Found no handlers" ]

[<EntryPoint>]
let main _ =
  startWebServer { defaultConfig with 
                                bindings = [Suave.Http.HttpBinding.mk Suave.Http.Protocol.HTTP System.Net.IPAddress.Any 3000us] } app
  
  
  0


