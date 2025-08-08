//------------------------------------------------------------------------------
import fs from "fs";
import path from "path";
//import nodeApiDotnet from "node-api-dotnet";

//------------------------------------------------------------------------------
// unsuccessful attempt to redirect js log to csharp program output
// const Console = nodeApiDotnet.System.Console;
// console.log = (...args) => Console.WriteLine("[log] " + args.join(" "));
// console.info = (...args) => Console.WriteLine("[info] " + args.join(" "));
// console.warn = (...args) => Console.WriteLine("[warn] " + args.join(" "));
// console.error = (...args) => Console.WriteLine("[error] " + args.join(" "));

//------------------------------------------------------------------------------
// So output js log to file to actually see what's going on somewhere
const logFilePath = path.resolve(__dirname, "js_console.log");
// Open and clear
fs.writeFileSync(logFilePath, "");
const logStream = fs.createWriteStream(logFilePath, { flags: "a" });

//------------------------------------------------------------------------------
// If object is not json serializable due to bigint or circular references, I 
// have code to handle those cases.
function logToFile(type: string, ...args: Array<any>) {
    const timestamp = new Date().toISOString();

    const messages = args.map(arg => {
        if (arg instanceof Error) {
            const message = arg.toString();
            const stack = arg.stack || '';
            return `${message}\n${stack}`;
        }
        if (typeof arg === 'object') {
            try {
                return JSON.stringify(arg, null, 2);
            } catch {
                return '[Unserializable Object]';
            }
        }
        return String(arg);
    });

    const line = `[${timestamp}] [${type}]\n${messages.join('\n')}\n`;
    logStream.write(line);
}

//------------------------------------------------------------------------------
// redirect js console output to file
console.log = (...args) => logToFile("log", ...args);
console.info = (...args) => logToFile("info", ...args);
console.warn = (...args) => logToFile("warn", ...args);
console.error = (...args) => logToFile("error", ...args);