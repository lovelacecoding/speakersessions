import pygame

from bullet import Bullet


WIDTH, HEIGHT = 800, 800

class Player(pygame.sprite.Sprite):
    def __init__(self, pos):
        super().__init__()
        raw_image = pygame.image.load("assets/player.png")
        self.image = pygame.transform.scale(raw_image, (64*2, 64*2))
        self.rect = self.image.get_rect(midbottom=pos)
        self.last_shot = 0
        self.cooldown = 250

    def update(self, keys):
        if keys[pygame.K_LEFT] or keys[pygame.K_a]:
            self.rect.x -= 4
        if keys[pygame.K_RIGHT] or keys[pygame.K_d]:
            self.rect.x += 4

        self.rect.clamp_ip(pygame.Rect(0, 0, WIDTH, HEIGHT))

    def shoot(self, now, bullets):
            if now - self.last_shot > self.cooldown:
                bullets.add(Bullet(self.rect.midtop))
                self.last_shot = now