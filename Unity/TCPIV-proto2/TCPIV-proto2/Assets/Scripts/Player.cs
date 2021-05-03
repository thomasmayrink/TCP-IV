using System;

public class Player
{
    public delegate void PositionEvent(Vector3 position);
    //public delegate void PosicionarEvent(Vector3 posicao);
    public event PositionEvent OnPositionChanged;
    //public evento PosicionarEvent OnPosicaoMudou;

    public Vector3 posicao
    {
        get
        {
            return _position;
        }
        set
        {
            if (_position != value)
            {
                _position = value;
                if(OnPositionChanged != null)
                {
                    OnPositionChanged(value);
                }
            }
        }
    }
    private Vector3 _position;
}