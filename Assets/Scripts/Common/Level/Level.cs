using System;
using System.Linq;
public class Level
{
    public event Action<Level, Action> LevelComplete;
    
    private char[,] _levelShape;

    private int _fieldsLeft;
    
    public ILevelContext Context { get; set; }
    public int Id { get; set; }

    public char[,] Objects
    {
        get => _levelShape;
    }

    public Level (int size)
    {
        _levelShape = new char[size, size];
    }

    public Level (char[,] levelShape)
    {
        _levelShape = levelShape;
        RefreshLevel();
    }

    public void RemoveField ()
    {
        _fieldsLeft--;
        if (_fieldsLeft <= 0)
        {
            LevelComplete?.Invoke(this, () => Context.LoadLevel(Id + 1));
            RefreshLevel();
        }
    }

    public void RefreshLevel ()
    {
        for (int x = 0; x < _levelShape.GetLength(0); x++)
        {
            for (int y = 0; y < _levelShape.GetLength(1); y++)
            {
                if (_levelShape[x, y] == 'g')
                {
                    _fieldsLeft++;
                }
            }
        }
    }
}
