export function applySchema(input: any, schema: any): any;
export function ch(...args: any[]): any;
export function debugLog(): void;
export function getVal(pth: any): any;
export function getValByPath(path: any, obj: any): any;
export namespace helpers {
    function def(val: any): any;
    function dict(dictionary: any): any;
    function filterUndefined(converter: any): any;
    function template(tpl: any, strong: any): any;
    function templateStrong(tpl: any): any;
    function toBoolean(input: any): any;
    function toNumber(input: any): any;
    function toString(input: any): any;
    function toUndefined(input: any): any;
    function valOrDef(def: any): any;
}
export function makeCb(fn: any): any;
export function makeConverter(schema: any): any;
export function makeMapConverter(convert: any): any;
export function map(fn: any): any;
