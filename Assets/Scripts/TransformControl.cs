using UnityEngine;
using RTG;  // 引入 RTGizmos 命名空间

public class TransformControl : MonoBehaviour
{
    public LayerMask selectableLayer;  // 公开的LayerMask，可以在外部设置层级
    private GameObject selectedObject;  // 当前选中的物体
    private RTGizmosEngine gizmosEngine;  // Gizmo引擎
    private ObjectTransformGizmo currentTransformGizmo;  // 当前的Transform Gizmo
    private enum GizmoMode { None, Move, Rotate, Scale } // 用于存储当前的 Gizmo 模式
    private GizmoMode currentMode = GizmoMode.Move; // 当前操作模式


    void Start()
    {
        gizmosEngine = RTGizmosEngine.Get;  
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  
        {
            SelectObjectByMouseClick();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            currentMode = GizmoMode.Move;   
            EnableMoveGizmo();   
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentMode = GizmoMode.Rotate; 
            EnableRotateGizmo();  
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            currentMode = GizmoMode.Scale;  
            EnableScaleGizmo();  
        }
    }

    void SelectObjectByMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);   
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayer))  
        {
            selectedObject = hit.collider.gameObject;   
            Debug.Log($"选中物体: {selectedObject.name}");   


            // 如果当前是 "缩放" 模式，则执行缩放操作，避免触发其他模式
            if (currentMode == GizmoMode.Move)
            {
                EnableMoveGizmo();  // 启用移动Gizmo
            }
            else if (currentMode == GizmoMode.Rotate)
            {
                EnableRotateGizmo();  // 启用旋转Gizmo
            }
            else if (currentMode == GizmoMode.Scale)
            {
                EnableScaleGizmo();  // 启用缩放Gizmo
            }
        }
    }

    void EnableMoveGizmo()
    {
        if (selectedObject != null)
        {
            // 每次切换前，移除当前的 Gizmo
            if (currentTransformGizmo != null)
            {
                gizmosEngine.RemoveGizmo(currentTransformGizmo.Gizmo);  // 移除旧的 Gizmo
            }

            // 创建并添加新的 Gizmo
            var transformGizmo = RTGizmosEngine.Get.CreateObjectMoveGizmo();  // 创建移动Gizmo
            transformGizmo.SetTargetObject(selectedObject);  // 设置选中的物体
            transformGizmo.SetTransformSpace(GizmoSpace.Local);  // 设置局部变换空间
            currentTransformGizmo = transformGizmo;  // 设置当前Gizmo为移动Gizmo

        }
    }

    void EnableRotateGizmo()
    {
        if (selectedObject != null)
        {
            // 每次切换前，移除当前的 Gizmo
            if (currentTransformGizmo != null)
            {
                gizmosEngine.RemoveGizmo(currentTransformGizmo.Gizmo);  // 移除旧的 Gizmo
            }

            // 创建并添加新的 Gizmo
            var transformGizmo = RTGizmosEngine.Get.CreateObjectRotationGizmo();  // 创建旋转Gizmo
            transformGizmo.SetTargetObject(selectedObject);  // 设置选中的物体
            transformGizmo.SetTransformSpace(GizmoSpace.Local);  // 设置局部变换空间
            currentTransformGizmo = transformGizmo;  // 设置当前Gizmo为旋转Gizmo

        }
    }

    void EnableScaleGizmo()
    {
        if (selectedObject != null)
        {
            // 每次切换前，移除当前的 Gizmo
            if (currentTransformGizmo != null)
            {
                gizmosEngine.RemoveGizmo(currentTransformGizmo.Gizmo);  // 移除旧的 Gizmo
            }

            // 创建并添加新的 Gizmo
            var transformGizmo = RTGizmosEngine.Get.CreateObjectScaleGizmo();  // 创建缩放Gizmo
            transformGizmo.SetTargetObject(selectedObject);  // 设置选中的物体
            transformGizmo.SetTransformSpace(GizmoSpace.Local);  // 设置局部变换空间
            currentTransformGizmo = transformGizmo;  // 设置当前Gizmo为缩放Gizmo

        }
    }
}
