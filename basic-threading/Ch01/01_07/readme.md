(https://www.backblaze.com/blog/whats-the-diff-programs-processes-and-threads)[https://www.backblaze.com/blog/whats-the-diff-programs-processes-and-threads]


### Thread vs Process

#### Threads 

- Run in parallel within a single process
- share memory with other threads running in the same application (process) 

#### Process

- Process are fully isolated from each other: threads have a limited degree of isolation. Threads share `heap memory` with other threads running in the sale application (process), even though they have local variables which actually as part of local memory (stack) that can't access by other threads.