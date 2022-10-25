/*
type JSONValue =
    | string
    | number
    | boolean
    | JSONObject
    | JSONArray;
*/

export interface JSONObject {
    [x: string]: JSONValue;
}

interface JSONArray extends Array<JSONValue> { }

type JSONValue =
    | string
    | number
    | boolean
    | { [x: string]: JSONValue }
    | Array<JSONValue>;