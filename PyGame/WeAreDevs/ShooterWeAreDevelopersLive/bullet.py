import pygame

class Bullet(pygame.sprite.Sprite):
    def __init__(self, pos):
        super().__init__()
        self.image = pygame.Surface((16, 32))
        self.image.fill((0, 255, 255))
        self.rect = self.image.get_rect(center=pos)

    def update(self):
        self.rect.y -= 6
        if self.rect.bottom < 0:
            self.kill()