from math import cos, sin
import numpy as np
import pygame


WIDTH, HEIGHT = 800, 600
DARKBLUE = (0, 0, 50)
LIGHTGREEN = (100, 255, 100)
RED = (255, 0, 0)
SCALE = 100
CIRCLE_POSITION = (WIDTH / 2, HEIGHT / 2)
ANGLE_INCREMENT = 0.01


pygame.init()
pygame.display.set_caption("3D Cube by ZKLSTP (@dabzse)")
screen = pygame.display.set_mode((WIDTH, HEIGHT))
clock = pygame.time.Clock()


points = [
    np.matrix([-1, -1, 1]),
    np.matrix([1, -1, 1]),
    np.matrix([1, 1, 1]),
    np.matrix([-1, 1, 1]),
    np.matrix([-1, -1, -1]),
    np.matrix([1, -1, -1]),
    np.matrix([1, 1, -1]),
    np.matrix([-1, 1, -1])
]


projection_matrix = np.matrix([[1, 0, 0], [0, 1, 0]])


def connect_points(i, j, pts):
    pygame.draw.line(screen, RED, (pts[i][0], pts[i][1]), (pts[j][0], pts[j][1]))


def main():
    angle = 0
    while True:
        clock.tick(60)
        for event in pygame.event.get():
            if event.type == pygame.QUIT or \
                    (event.type == pygame.KEYDOWN and event.key == pygame.K_ESCAPE):
                pygame.quit()
                exit()


        rotation_x = np.matrix([
            [1, 0, 0],
            [0, cos(angle), -sin(angle)],
            [0, sin(angle), cos(angle)]
        ])

        rotation_y = np.matrix([
            [cos(angle), 0, sin(angle)],
            [0, 1, 0],
            [-sin(angle), 0, cos(angle)]
        ])

        rotation_z = np.matrix([
            [cos(angle), -sin(angle), 0],
            [sin(angle), cos(angle), 0],
            [0, 0, 1]
        ])

        angle += ANGLE_INCREMENT
        screen.fill(DARKBLUE)

        projected_points = []
        for point in points:
            rotated = np.dot(rotation_z, point.reshape((3, 1)))
            rotated = np.dot(rotation_x, rotated)
            rotated = np.dot(rotation_y, rotated)
            projected = np.dot(projection_matrix, rotated)
            x = int(projected[0, 0] * SCALE + CIRCLE_POSITION[0])
            y = int(projected[1, 0] * SCALE + CIRCLE_POSITION[1])
            projected_points.append([x, y])
            pygame.draw.circle(screen, LIGHTGREEN, (x, y), 5)

        for p in range(4):
            connect_points(p, (p + 1) % 4, projected_points)
            connect_points(p + 4, ((p + 1) % 4) + 4, projected_points)
            connect_points(p, p + 4, projected_points)

        pygame.display.update()

if __name__ == "__main__":
    main()
