// @ts-nocheck
import WS from "ws";

console.log(`[node-version] ${process.version}`);


// Node 20 does not have websocket (22+)
globalThis.WebSocket = WS;
// Node 20 does not have navigator(22+)
globalThis.navigator = {};
// Latest Livelink has this created from Livelink.#audio_player
globalThis.AudioContext = class {
    constructor() {
        this.sampleRate = 44100;
        this.currentTime = 0;
        this.state = "running";
    }
    createOscillator() {
        return {
            type: "sine",
            frequency: { value: 440 },
            connect: () => { },
            start: () => { },
            stop: () => { },
        };
    }
    createGain() {
        return {
            gain: { value: 1 },
            connect: () => { },
        };
    }
    destination = {};
};