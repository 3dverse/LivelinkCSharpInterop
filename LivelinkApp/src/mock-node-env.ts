// @ts-nocheck
import WS from "ws";

console.log(`[node-version] ${process.version}`);


// Node 20 does not have websocket (22+)
globalThis.WebSocket = WS;
// Node 20 does not have navigator(22+)
globalThis.navigator = {};