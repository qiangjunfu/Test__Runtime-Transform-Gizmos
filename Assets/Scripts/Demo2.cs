using System.Collections;
using System.Collections.Generic;
using RTG;
using UnityEngine;

public class Demo2 : MonoBehaviour
{
    private GameObject selectedObject;  // 当前选中的物体


    private void Start()
    {
        //// Create transform gizmos
        //var moveTargetNames = new string[] { "Blue Cube", "Sphere" };
        //foreach (var targetName in moveTargetNames)
        //{
        //    var transformGizmo = RTGizmosEngine.Get.CreateObjectMoveGizmo();

        //    GameObject targetObject = GameObject.Find(targetName);
        //    transformGizmo.SetTargetObject(targetObject);
        //    transformGizmo.Gizmo.MoveGizmo.SetVertexSnapTargetObjects(new List<GameObject> { targetObject });
        //    transformGizmo.SetTransformSpace(GizmoSpace.Local);
        //}

        //var rotationTargetNames = new string[] { "Cylinder", "Red Cube" };
        //foreach (var targetName in rotationTargetNames)
        //{
        //    var transformGizmo = RTGizmosEngine.Get.CreateObjectRotationGizmo();

        //    GameObject targetObject = GameObject.Find(targetName);
        //    transformGizmo.SetTargetObject(targetObject);
        //    transformGizmo.SetTransformSpace(GizmoSpace.Local);
        //}

        //var scaleTargetNames = new string[] { "Cylinder (1)", "Sphere (1)" };
        //foreach (var targetName in scaleTargetNames)
        //{
        //    var transformGizmo = RTGizmosEngine.Get.CreateObjectScaleGizmo();

        //    GameObject targetObject = GameObject.Find(targetName);
        //    transformGizmo.SetTargetObject(targetObject);
        //    transformGizmo.SetTransformSpace(GizmoSpace.Local);
        //}

        //var universalTargetNames = new string[] { "Blue Cube (1)", "Green Cube" };
        //foreach (var targetName in universalTargetNames)
        //{
        //    var transformGizmo = RTGizmosEngine.Get.CreateObjectUniversalGizmo();

        //    GameObject targetObject = GameObject.Find(targetName);
        //    transformGizmo.SetTargetObject(targetObject);
        //    transformGizmo.Gizmo.UniversalGizmo.SetMvVertexSnapTargetObjects(new List<GameObject> { targetObject });
        //    transformGizmo.SetTransformSpace(GizmoSpace.Local);
        //}

        //// Create collider gizmos
        //var colliderObject = GameObject.Find("Cube_BoxCollider");
        //var gizmo = RTGizmosEngine.Get.CreateGizmo();
        //var boxColliderGizmo = gizmo.AddBehaviour<BoxColliderGizmo3D>();
        //boxColliderGizmo.SetTargetCollider(colliderObject.GetComponent<BoxCollider>());

        //colliderObject = GameObject.Find("Sphere_SphereCollider");
        //gizmo = RTGizmosEngine.Get.CreateGizmo();
        //var sphereColliderGizmo = gizmo.AddBehaviour<SphereColliderGizmo>();
        //sphereColliderGizmo.SetTargetCollider(colliderObject.GetComponent<SphereCollider>());

        //colliderObject = GameObject.Find("Capsule_CapsuleCollider");
        //gizmo = RTGizmosEngine.Get.CreateGizmo();
        //var capsuleColliderGizmo = gizmo.AddBehaviour<CapsuleColliderGizmo3D>();
        //capsuleColliderGizmo.SetTargetCollider(colliderObject.GetComponent<CapsuleCollider>());

        //// Create light gizmos
        //var lightObject = GameObject.Find("Directional Light");
        //gizmo = RTGizmosEngine.Get.CreateGizmo();
        //var dirLightGizmo = gizmo.AddBehaviour<DirectionalLightGizmo3D>();
        //dirLightGizmo.SetTargetLight(lightObject.GetComponent<Light>());

        //lightObject = GameObject.Find("Point Light");
        //gizmo = RTGizmosEngine.Get.CreateGizmo();
        //var pointLightGizmo = gizmo.AddBehaviour<PointLightGizmo3D>();
        //pointLightGizmo.SetTargetLight(lightObject.GetComponent<Light>());

        //lightObject = GameObject.Find("Spot Light");
        //gizmo = RTGizmosEngine.Get.CreateGizmo();
        //var spotLightGizmo = gizmo.AddBehaviour<SpotLightGizmo3D>();
        //spotLightGizmo.SetTargetLight(lightObject.GetComponent<Light>());

        //// Create terrain gizmos
        //// Note: In order to use the terrain gizmo, you first need to click on the terrain.
        //var terrainObject = GameObject.Find("Terrain");
        //gizmo = RTGizmosEngine.Get.CreateGizmo();
        //var terrainGizmo = gizmo.AddBehaviour<TerrainGizmo>();
        //terrainGizmo.SetTargetTerrain(terrainObject.GetComponent<Terrain>());
    }


    void Update()
    {
        // 检测鼠标点击以选择物体
        if (Input.GetMouseButtonDown(0)) // 鼠标左键点击
        {
            SelectObjectByMouseClick();
        }

    }

    // 用鼠标点击选中物体
    void SelectObjectByMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // 从鼠标位置发射射线
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))  // 检测射线是否碰撞到物体
        {
            selectedObject = hit.collider.gameObject;  // 选中被点击的物体
            Debug.Log($"选中物体: {selectedObject.name}");  // 输出选中的物体名称


            var transformGizmo = RTGizmosEngine.Get.CreateObjectRotationGizmo();

            transformGizmo.SetTargetObject(selectedObject);
            transformGizmo.SetTransformSpace(GizmoSpace.Local);
        }
    }


}
