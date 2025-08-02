from counter import Counter

class Clock:
    def __init__(self):
        self.id = "SWS01358"
        self.is_12hr = self._is_12_hour_format()
        self.hour = Counter("Hour")
        self.min = Counter("Minute")
        self.sec = Counter("Second")

    def _is_12_hour_format(self):
        last_char = self.id[-1]
        return last_char.isdigit() and int(last_char) <= 5

    def tick(self):
        self.sec.increment()
        if self.sec.ticks >= 60:
            self.sec.reset()
            self.min.increment()
            if self.min.ticks >= 60:
                self.min.reset()
                self.hour.increment()
                if self.hour.ticks >= (12 if self.is_12hr else 24):
                    self.hour.reset()

    def set_time(self, h, m, s):
        for _ in range(h):
            self.hour.increment()
        for _ in range(m):
            self.min.increment()
        for _ in range(s):
            self.sec.increment()

    def reset(self):
        self.hour.reset()
        self.min.reset()
        self.sec.reset()

    def __str__(self):
        return f"{self.hour.ticks:02}:{self.min.ticks:02}:{self.sec.ticks:02}"
