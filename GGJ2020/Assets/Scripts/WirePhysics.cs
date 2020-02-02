using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePhysics : MonoBehaviour
{
    [SerializeField] float lineLength = 1;
    [SerializeField] int accuracyItirations = 5;


    [Header("Pointers")]
    [SerializeField] Transform WirePlugAttachementPoint;
    [SerializeField]  Transform StaticWireSide;

    [SerializeField] List<Material> colourMaterials;

    int particleAmmount;
  
    class LineParticle
    {
        public Vector3 oldPosition = Vector3.zero;
        public Vector3 position = Vector3.zero;
        public Vector3 accelleration = Physics.gravity;
        public float dragPercentage = 0.0f;
    }

    List<LineParticle> LineParticles = new List<LineParticle>();

    void Start()
    {
        particleAmmount = GetComponent<LineRenderer>().positionCount;

        for (int i = 0; i < particleAmmount; i++)
        {
            LineParticles.Add(new LineParticle());
            LineParticles[i].position = Vector3.Lerp(StaticWireSide.position, WirePlugAttachementPoint.position,(float)(i)/(float)(particleAmmount));
            LineParticles[i].oldPosition = LineParticles[i].position;
        }

        LineParticles[1].dragPercentage = 0.9f;
        LineParticles[LineParticles.Count - 2].dragPercentage = 0.9f;

   
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        LineParticles[LineParticles.Count - 1].position = WirePlugAttachementPoint.position;

        LineParticles[0].position = StaticWireSide.position;


        for (int i = 0; i < LineParticles.Count - 1; i++)
        {
            Verlet(LineParticles[i]);
        }


        for (int k = 0; k < accuracyItirations; k++)
        {
            for (int i = 0; i < LineParticles.Count - 1; i++)
            {
                PoleConstraint(LineParticles[i], LineParticles[i + 1], lineLength / (float)LineParticles.Count);
            }
        }


        if (!WirePlugAttachementPoint.GetComponentInParent<Rigidbody>().isKinematic)
        {
            WirePlugAttachementPoint.GetComponentInParent<Rigidbody>().AddForceAtPosition((LineParticles[LineParticles.Count - 1].position - WirePlugAttachementPoint.position), WirePlugAttachementPoint.position, ForceMode.VelocityChange);
        }


        Vector3[] linePositions = new Vector3[LineParticles.Count];
        for (int i = 0; i < LineParticles.Count; i++)
        {
            linePositions[i] = LineParticles[i].position;
        }

        linePositions[0] = StaticWireSide.position;
        linePositions[LineParticles.Count - 1] = WirePlugAttachementPoint.position;
        GetComponent<LineRenderer>().SetPositions(linePositions);
    }



    private void Verlet(LineParticle p)
    {
        var temp = p.position;
        p.position += ((p.position - p.oldPosition) * (1.0f - p.dragPercentage)) + (p.accelleration * Time.fixedDeltaTime * Time.fixedDeltaTime);
        p.oldPosition = temp;
    }

    private void PoleConstraint(LineParticle p1, LineParticle p2, float restLength)
    {
        var delta = p2.position - p1.position;

        var deltaLength = delta.magnitude;

        var diff = (deltaLength - restLength) / deltaLength;

        p1.position += delta * diff * 0.5f;
        p2.position -= delta * diff * 0.5f;
    }
}
