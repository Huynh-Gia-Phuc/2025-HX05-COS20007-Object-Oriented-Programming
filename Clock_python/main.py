import tracemalloc
from counter import Counter
from clock import Clock

def print_counters(counters):
    for counter in counters:
        print(f"Name is {counter.name}")
        print(f"Tick is {counter.ticks}")

def main():
    # Starting the monitoring
    tracemalloc.start()
    
    my_counters = [None] * 3
    my_counters[0] = Counter("Counter 1")
    my_counters[1] = Counter("Counter 2")
    my_counters[2] = my_counters[0]  # same reference as counter 1

    for _ in range(9):
        my_counters[0].increment()
    for _ in range(14):
        my_counters[1].increment()

    print("Before reset:")
    print_counters(my_counters)

    my_counters[2].reset()

    print("\nAfter reset:")
    print_counters(my_counters)

    # Optional Clock demo
    print("\nClock demo:")
    clock = Clock()
    clock.set_time(11, 59, 58)
    for _ in range(5):
        clock.tick()
        print(clock)
    
    # Display total memory usage
    current, peak = tracemalloc.get_traced_memory()
    print(f"\nTotal memory usage: {current / 1024:.2f} KB")
    print(f"Peak memory usage: {peak / 1024:.2f} KB")
    
    # Stopping the library
    tracemalloc.stop()

if __name__ == "__main__":
    main()
