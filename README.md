# O-Jantar-dos-Fil-sofos
O Jantar dos Filósofos é um exemplo clássico de sincronização de processos em sistemas operacionais e é fundamental para entender como gerenciar recursos compartilhados em um ambiente concorrente.

Imagine cinco filósofos sentados em torno de uma mesa circular, com um prato de comida em frente a cada um. Entre cada par de pratos, há um garfo. Os filósofos passam o tempo pensando e, ocasionalmente, tentam comer. Para comer, um filósofo precisa ter acesso a dois garfos: o garfo à sua esquerda e o garfo à sua direita. Se um filósofo não conseguir obter os dois garfos, ele não pode comer e deve continuar pensando.




Você deve implementar o Jantar dos Filósofos em C#, utilizando threads para simular os filósofos e os garfos como recursos compartilhados. O objetivo é garantir que os filósofos possam comer sem que ocorram problemas de sincronização, como:
: Quando dois ou mais processos ficam bloqueados indefinidamente, esperando por recursos que nunca serão liberados.
: Quando um processo nunca consegue acessar os recursos necessários porque outros processos estão sempre utilizando-os.
: Quando os processos estão constantemente mudando de estado, mas não conseguem progredir.






Crie uma classe Filosofo que represente um filósofo. Essa classe deve ter um método Viver() que simula o filósofo pensando e tentando comer.
Utilize threads para executar o método Viver() de cada filósofo concorrentemente.
Implemente a lógica para que os filósofos obtenham e liberem os garfos. Você pode usar lock, SemaphoreSlim ou outras estruturas de sincronização disponíveis em C#.
Certifique-se de que a implementação evite os problemas de deadlock, starvation e livelock.





Utilize SemaphoreSlim para representar os garfos, pois isso permite controlar o acesso a eles de forma eficiente.
Para evitar o deadlock, considere implementar uma estratégia como "pegar os garfos em uma ordem específica" ou "liberar um garfo se não conseguir pegar o outro".
Para evitar a starvation, certifique-se de que todos os filósofos tenham uma chance justa de comer. Isso pode ser alcançado implementando uma política de fila ou utilizando um mecanismo que garanta a ordem de acesso aos garfos.
Utilize Console.WriteLine() para imprimir mensagens que indiquem o que está acontecendo com os filósofos (por exemplo, "Filósofo X está pensando", "Filósofo Y está comendo", etc.). Isso ajudará a visualizar o comportamento do programa.
