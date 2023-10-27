using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField] public Transform End;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private int _segmentCount;
    [SerializeField] public float RopeLength;
    [SerializeField] public float GravityPower = 1f;

    private Segment[] _segments;
    private Vector3[] _positions;

    private void Awake()
    {
        _line.useWorldSpace = true;
        _segments = new Segment[_segmentCount];
        _positions = new Vector3[_segmentCount];    
        
        for(int i = 0; i < _segmentCount; i++)
        {
            _segments[i] = new Segment() { pos = transform.position, velocity = Vector3.zero };
        }
    }

    private void FixedUpdate()
    {
        _segments[0].pos = transform.position;

        
        for(int i = 1; i < _segments.Length; i++) {
            var cur = _segments[i];

            cur.velocity += Time.fixedDeltaTime * Physics.gravity * GravityPower;
            cur.pos += Time.fixedDeltaTime * cur.velocity;
        }

        for(int i = 1; i < _segments.Length; i++)
        {
            var cur = _segments[i];
            var prev = _segments[i - 1];

            if ((cur.pos - prev.pos).magnitude > RopeLength / _segmentCount)
            {
                var diff = (cur.pos - prev.pos).magnitude - RopeLength / _segmentCount;
                var movement = (prev.pos - cur.pos).normalized * diff;

                cur.pos += movement;
                cur.velocity += movement;
            }
        }

        for(int i = 0; i < _segments.Length; i++)
        {
            _positions[i] = _segments[i].pos;
        }
        _line.positionCount = _segments.Length;
        _line.SetPositions(_positions);

        End.position = _segments[^1].pos;
    }

    public class Segment
    {
        public Vector3 pos, velocity;
    }
}
