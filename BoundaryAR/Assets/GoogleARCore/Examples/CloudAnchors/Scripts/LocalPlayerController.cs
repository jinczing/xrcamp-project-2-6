//-----------------------------------------------------------------------
// <copyright file="LocalPlayerController.cs" company="Google">
//
// Copyright 2018 Google LLC. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.CloudAnchors
{
    using UnityEngine;
    using UnityEngine.Networking;
    using GoogleARCore.Examples.ObjectManipulation;

    /// <summary>
    /// Local player controller. Handles the spawning of the networked Game Objects.
    /// </summary>
#pragma warning disable 618
    public class LocalPlayerController : NetworkBehaviour
#pragma warning restore 618
    {
        /// <summary>
        /// The Star model that will represent networked objects in the scene.
        /// </summary>
        public GameObject StarPrefab;
        public GameObject LadderPrefab;
        public GameObject MonitorPrefab;
        public GameObject PawnPrefab;
        public GameObject PortalPrefab;

        public GameObject ManipulatorPrefab;

        public GameObject Head;
        public GameObject LeftHand;
        public GameObject RightHand;

        /// <summary>
        /// The Anchor model that will represent the anchor in the scene.
        /// </summary>
        public GameObject AnchorPrefab;

        /// <summary>
        /// The Unity OnStartLocalPlayer() method.
        /// </summary>
        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();

            // A Name is provided to the Game Object so it can be found by other Scripts, since this
            // is instantiated as a prefab in the scene.
            gameObject.name = "LocalPlayer";
        }

        /// <summary>
        /// Will spawn the origin anchor and host the Cloud Anchor. Must be called by the host.
        /// </summary>
        /// <param name="position">Position of the object to be instantiated.</param>
        /// <param name="rotation">Rotation of the object to be instantiated.</param>
        /// <param name="anchor">The ARCore Anchor to be hosted.</param>
        public void SpawnAnchor(Vector3 position, Quaternion rotation, Component anchor)
        {
            // Instantiate Anchor model at the hit pose.
            var anchorObject = Instantiate(AnchorPrefab, position, rotation);

            // Anchor must be hosted in the device.
            anchorObject.GetComponent<AnchorController>().HostLastPlacedAnchor(anchor);

            PilotNetwork.instance.SetupPilot();
            GameObject.Find("Head-f").GetComponent<IkTracker>().SetupIkTracker();
            GameObject.Find("LeftHand-f").GetComponent<IkTracker>().SetupIkTracker();
            GameObject.Find("RightHand-f").GetComponent<IkTracker>().SetupIkTracker();

            // Host can spawn directly without using a Command because the server is running in this
            // instance.
#pragma warning disable 618
            NetworkServer.Spawn(anchorObject);
#pragma warning restore 618
        }

        /// <summary>
        /// A command run on the server that will spawn the Star prefab in all clients.
        /// </summary>
        /// <param name="position">Position of the object to be instantiated.</param>
        /// <param name="rotation">Rotation of the object to be instantiated.</param>
#pragma warning disable 618
        [Command]
#pragma warning restore 618
        public void CmdSpawnStar(Vector3 position, Quaternion rotation)
        {
            // Instantiate Star model at the hit pose.
            var starObject = Instantiate(StarPrefab, position, rotation);

            // Spawn the object in all clients.
#pragma warning disable 618
            NetworkServer.Spawn(starObject);
#pragma warning restore 618

        }
        /// <summary>
        /// A command run on the server that will spawn the Ladder prefab in all clients.
        /// </summary>
        /// <param name="position">Position of the object to be instantiated.</param>
        /// <param name="rotation">Rotation of the object to be instantiated.</param>
#pragma warning disable 618
        [Command]
#pragma warning restore 618
        public void CmdSpawnLadder(Vector3 position, Quaternion rotation)
        {
            // Instantiate Star model at the hit pose.
            var ladderObject = Instantiate(LadderPrefab, position, rotation);

            // Spawn the object in all clients.
#pragma warning disable 618
            NetworkServer.Spawn(ladderObject);
#pragma warning restore 618
        }

        /// <summary>
        /// A command run on the server that will spawn the Monitor prefab in all clients.
        /// </summary>
        /// <param name="position">Position of the object to be instantiated.</param>
        /// <param name="rotation">Rotation of the object to be instantiated.</param>
#pragma warning disable 618
        [Command]
#pragma warning restore 618
        public void CmdSpawnPortal(Vector3 position, Vector3 direction)
        {
            // Instantiate Star model at the hit pose.
            var portalObject = Instantiate(PortalPrefab, position, Quaternion.identity);
            portalObject.transform.forward = direction;

            // Spawn the object in all clients.
#pragma warning disable 618
            NetworkServer.Spawn(portalObject);
#pragma warning restore 618
        }


        /// A command run on the server that will spawn the Pawn prefab in all clients.
        /// </summary>
        /// <param name="position">Position of the object to be instantiated.</param>
        /// <param name="rotation">Rotation of the object to be instantiated.</param>
#pragma warning disable 618
        [Command]
#pragma warning restore 618
        public void CmdSpawnPawn(Vector3 position, Quaternion rotation)
        {
            // Instantiate Star model at the hit pose.
            var pawnObject = Instantiate(PawnPrefab, position, rotation);

            // Spawn the object in all clients.
#pragma warning disable 618
            NetworkServer.Spawn(pawnObject);
#pragma warning restore 618

            //// Instantiate manipulator.
            //var manipulator =
            //    Instantiate(ManipulatorPrefab, position, rotation);

            //// Make game object a child of the manipulator.
            //gameObject.transform.parent = manipulator.transform;

            //// Select the placed object.
            //manipulator.GetComponent<Manipulator>().Select();
        }
    }
    }
