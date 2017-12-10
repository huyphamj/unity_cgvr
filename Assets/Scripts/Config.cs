using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config {
	/* ========================================
					FOR MONSTER
	========================================= */
	public static float MONSTER_DESTROY_TIME = 2.5f;

	public static int ZOMBIE_NORMAL_HP = 3;
	public static int ZOMBIE_DAMAGE = 2;
	public static float ZOMBIE_NORMAL_ATTACK_TIME = 2.0f;
	public static float ZOMBIE_NORMAL_ATTACK_RANGE = 8.0f;
	public static float ZOMBIE_MOVE_SPEED = 0.06f;
	public static float ZOMBIE_DELAY_AFTER_ATTACK = 0.5f;

	public static int SKELETON_HP = 2;
	public static int SKELETON_DAMAGE = 1;
	public static float SKELETON_ATTACK_TIME = 1.0f;
	public static float SKELETON_ATTACK_RANGE = 2f;
	public static float SKELETON_MOVE_SPEED = 0.1f;
	public static float SKELETON_DELAY_AFTER_ATTACK = 0.0f;

	public static int WIZARD_HP = 7;
	public static int WIZARD_DAMAGE = 5;
	public static float WIZARD_ATTACK_TIME = 10f;
	public static float WIZARD_ATTACK_RANGE = 13.0f;
	public static float WIZARD_MOVE_SPEED = 0.05f;
	public static float WIZARD_DELAY_AFTER_ATTACK = 1.0f;

	public static int SUMMON_HP = 1;
	public static int SUMMON_DAMAGE = 1;
	public static float SUMMON_ATTACK_TIME = 1.5f;
	public static float SUMMON_ATTACK_RANGE = 2f;
	public static float SUMMON_MOVE_SPEED = 0.07f;
	public static float SUMMON_DELAY_AFTER_ATTACK = 0.5f;

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
