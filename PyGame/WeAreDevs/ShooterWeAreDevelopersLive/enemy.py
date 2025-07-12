import pygame
import random

WIDTH, HEIGHT = 800, 800

class Enemy(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()
        raw_image = pygame.image.load("assets/orange_bug.png")
        self.image = pygame.transform.scale(raw_image, (64, 64))
        pos = random.randint(20, WIDTH - 20)
        self.rect = self.image.get_rect(midtop=(pos, -10))
        self.speed = random.randint(6, 10)

    def update(self):
        self.rect.y += self.speed
        if self.rect.top > HEIGHT:
            self.kill()