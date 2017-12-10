using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config {
	/* ========================================
					FOR MONSTER
	========================================= */
	public static float MONSTER_DESTROY_TIME = 2.0f;

	public static int ZOMBIE_NORMAL_HP = 3;
	public static int ZOMBIE_DAMAGE = 2;
	public static float ZOMBIE_NORMAL_ATTACK_TIME = 2.0f;
	public static float ZOMBIE_NORMAL_ATTACK_RANGE = 8.0f;
	public static float ZOMBIE_MOVE_SPEED = 0.04f;

	public static int SKELETON_HP = 1;
	public static int SKELETON_DAMAGE = 1;
	public static float SKELETON_ATTACK_TIME = 1.0f;
	public static float SKELETON_ATTACK_RANGE = 3.0f;
	public static float SKELETON_MOVE_SPEED = 0.1f;

	/* ========================================
					FOR LEVELS
	========================================= */
	public static float ZOMBIE_GENERATE_SCHEDULE = 2.5f;

	/* ========================================
					FOR BULLETS
	========================================= */
	public static float BULLET_PISTOL_SPEED = 1.0f;
	public static int BULLET_PISTOL_DAMAGE = 1;
	public static float BULLET_PISTOL_DESTRUCT_TIME = 0.2f;

	/* ========================================
					FOR PLAYER
	========================================= */
	public static float PLAYER_ATTACK_SPEED = 0.3f;
	public static float PLAYER_MOVE_SPEED = 0.06f;
}
