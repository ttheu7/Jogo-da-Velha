char[] symbol = new char[2] { 'X', 'O'};
int k = new Random().Next(0, 2);
string trueWinner = "Ninguém venceu!";

bool checkFill(char[,] matrix)
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (matrix[i, j] == '\0')
            {
                return false;
            }
        }
    }
    return true;
}

void checkWin(char[,] matrix)
{
    for (int i = 0; i < 3; i++)
    {
        if (matrix[i, 0] != '\0' && matrix[i, 0] == matrix[i, 1] && matrix[i, 1] == matrix[i, 2])
        {
            trueWinner = $"Jogador {matrix[i, 0]}!";
        }
        else if (matrix[0, i] != '\0' && matrix[0, i] == matrix[1, i] && matrix[1, i] == matrix[2, i])
        {
            trueWinner = $"Jogador {matrix[0, i]}!";
        }
    }
    
    if (matrix[0, 0] != '\0' && matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2])
    {
        trueWinner = $"Jogador {matrix[0, 0]}!";
    }
    else if (matrix[0, 2] != '\0' && matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0])
    {
        trueWinner = $"Jogador {matrix[0, 2]}!";
    }
}

void startGame()
{
    char[,] game = new char[3, 3];

    while (!checkFill(game))
    {
        int i = new Random().Next(0, 3);
        int j = new Random().Next(0, 3);

        if (game[i, j] == '\0')
        {
            game[i, j] = symbol[k];
            k = 1 - k;
        }

        if (trueWinner == "Ninguém venceu!")
        {
            checkWin(game);
        }
    }

    Console.WriteLine("======================================");
    printGame(game);
    Console.WriteLine($"Vencedor Verdadeiro: {trueWinner}");
    Console.WriteLine($"Resultado Final: {checkGame(game)}");
    Console.WriteLine("======================================");
}

void printGame(char[,] game)
{
    Console.WriteLine("Estado Final do Jogo: ");
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(game[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

string checkGame(char[,] game)
{
    if (game[0, 0] == game[1, 1] && game[1, 1] == game[2, 2])
    {
        return $"O jogador {game[0, 0]} venceu!";
    }
    else if (game[0, 2] == game[1, 1] && game[1, 1] == game[2, 0])
    {
        return $"O jogador {game[0, 2]} venceu!";
    }

    for (int i = 0; i < 3; i++)
    {
        if (game[i, 0] == game[i, 1] && game[i, 1] == game[i, 2])
        {
            return $"O jogador {game[i, 0]} venceu!";
        }
        else if (game[0, i] == game[1, i] && game[1, i] == game[2, i])
        {
            return $"O jogador {game[0, i]} venceu!";
        }
    }

    return "Deu Velha!!";
}

startGame();
