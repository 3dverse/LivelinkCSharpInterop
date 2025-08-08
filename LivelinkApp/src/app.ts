//------------------------------------------------------------------------------
import { Livelink, Entity, type Vec3 } from "@3dverse/livelink";


//------------------------------------------------------------------------------
import config from "./config.js";
import "./logtrace.js";
import "./mock-node-env.js";

//------------------------------------------------------------------------------
let interval: NodeJS.Timeout;
let instance: Livelink;
let cubes: Entity[] = [];

export function test() { return 'test'; }

//------------------------------------------------------------------------------
export async function connect(): Promise<void> {
    try {
        //@ts-ignore
        Livelink._api_url = config.livelink.apiUrl;
        //@ts-ignore
        Livelink._editor_url = config.livelink.editorUrl;

        instance = await Livelink.join_or_start({
            scene_id: config.session.sceneId,
            token: config.session.token,
            is_transient: true,
        });

        await instance.configureHeadlessClient();

        instance.startStreaming();
    } catch (error: unknown) {
        console.error(error); 
        //process.exit(1);
    }
}

//------------------------------------------------------------------------------
export async function disconnect(): Promise<void> {
    try {
        if (instance) {
            await instance.disconnect();
        }
    } catch (error: unknown) {
        console.error(error);
        //process.exit(1);
    }
}

//------------------------------------------------------------------------------
export async function startAnimation(): Promise<void> {
    const { entity, onUpdate } = await createCube(instance);
    cubes.push(entity);

    const start_time = Date.now();
    interval = setInterval(() => {
        onUpdate({ elapsed_time: (Date.now() - start_time) / 1000 });
    }, 1000 / 60);
}

//------------------------------------------------------------------------------
export async function stopAnimations(): Promise<void> {
    if (interval) {
        clearInterval(interval);
    }
    if (cubes.length > 0) {
        await instance.scene.deleteEntities({ entities: cubes });
        cubes = [];
    }
}

//------------------------------------------------------------------------------
const Space = [25, 25, 25] as const;
async function createCube(instance: Livelink) {
    const speed = 1;
    const initial_position = Space.map((v) => (Math.random() - 0.5) * v) as Vec3;
    const translation_axis = Space.map((v) => (Math.random() - 0.5) * v) as Vec3;
    const rotation_axis = [
        360 * Math.random(),
        360 * Math.random(),
        360 * Math.random(),
    ];
    const sin_delay = Math.random() * 2 * Math.PI;

    const entity = await instance.scene.newEntity({
        name: "Cube",
        components: {
            mesh_ref: { value: "c45d7c05-7c06-4939-b70c-8dd5ce1212bc" },
            local_transform: {
                position: initial_position,
            },
            material: {
                isDoubleSided: false,
                shaderRef: "f2a549e5-4f72-4cef-a5ab-48873c209e0c",
                constantsJSON: {
                    MATERIAL_UNTEXTURED: true,
                },
                dataJSON: {
                    albedo: [Math.random(), Math.random(), Math.random()],
                    emission: [0, 0, 0],
                },
            },
        },
        options: { delete_on_client_disconnection: true },
    });

    const onUpdate = ({ elapsed_time }: { elapsed_time: number }) => {
        entity.local_transform!.position = translation_axis.map(
            (v, i) =>
                initial_position[i] + Math.sin(sin_delay + elapsed_time * speed) * v
        ) as Vec3;

        entity.local_transform!.eulerOrientation = rotation_axis.map(
            (v) => Math.sin(sin_delay + elapsed_time * speed) * v
        ) as Vec3;
    };

    return { entity, onUpdate };
}
