using System;
using Unity.VisualScripting;
using UnityEngine;

public class JumpUp : MonoBehaviour
{

    private abstract class State
    {
        protected JumpUp bird;
        public State(JumpUp jumpUp)
        {
            this.bird = jumpUp;
        }
        public abstract void applyUpdates();
        public abstract void collision(Collision2D collision);
    }
    private class Alive : State
    {
        public Alive(JumpUp jumpUp) : base(jumpUp) { }
        public override void applyUpdates()
        {
            base.bird.checkOutOfBounds();
            base.bird.applyPlayerCommands();
        }
        public override void collision(Collision2D collision)
        {
            base.bird.die();
        }
    }
    private class Dead : State
    {
        public Dead(JumpUp jumpUp) : base(jumpUp) { }
        public override void applyUpdates() { }
        public override void collision(Collision2D collision) { }
    }

    public Rigidbody2D model;
    public float jumpStrength = 4f;
    public UpdateManager logic;
    private State state;

    void Start()
    {
        state = new Alive(this);
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<UpdateManager>();
    }

    void Update()
    {
        this.state.applyUpdates();
    }

    protected void applyPlayerCommands()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            model.linearVelocityY = jumpStrength;
            Debug.Log(transform.position.y);
        }
    }

    protected void checkOutOfBounds()
    {
        if (Math.Abs(transform.position.y) > 5.2)
        {
            this.die();
        }
    }

    protected void die()
    {
        logic.gameOver();
        this.state = new Dead(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.state.collision(collision);
    }

}
