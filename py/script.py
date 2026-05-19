import keyboard
import time

keys = ['d', 'f', 'j', 'k']
lane_map = {k: i for i, k in enumerate(keys)}

tick_rate = 0.1  # row speed (100ms per line)
window = 0.1    # chord window (50ms grouping)

chart = []

current_row = ['-'] * len(keys)
pressed_keys = []

last_tick = time.time()

print("Recording... ESC to stop.")

# 🎮 GLOBAL KEY LISTENER
def on_key(event):
    if event.event_type == keyboard.KEY_DOWN:
        if event.name in lane_map:
            pressed_keys.append((event.name, time.time()))
keyboard.hook(on_key)

while True:
    if keyboard.is_pressed('esc'):
        break

    now = time.time()

    # collect key presses in real time
    event = keyboard.read_event(suppress=False)

    if event.event_type == keyboard.KEY_DOWN:
        key = event.name

        if key in lane_map:
            pressed_keys.append((key, now))

    # tick: flush row
    if now - last_tick >= tick_rate:
        row = ['-'] * len(keys)

        # only keep keys inside the window
        valid = [k for k, t in pressed_keys if now - t <= window]

        for k in valid:
            row[lane_map[k]] = '0'

        chart.append("".join(row))

        pressed_keys = []  # reset
        last_tick += tick_rate

# save file
with open("chart.txt", "w") as f:
    f.write("\n".join(chart))

print("Saved chart.txt")