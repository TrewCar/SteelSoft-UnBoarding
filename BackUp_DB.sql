PGDMP         )                |         
   unboarding    15.4    15.3                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    83993 
   unboarding    DATABASE     ~   CREATE DATABASE unboarding WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE unboarding;
                postgres    false            �            1259    84051 	   infousers    TABLE     ^   CREATE TABLE public.infousers (
    id_user integer NOT NULL,
    id_task integer NOT NULL
);
    DROP TABLE public.infousers;
       public         heap    postgres    false            �            1259    83997 	   questions    TABLE     �   CREATE TABLE public.questions (
    id integer DEFAULT 0 NOT NULL,
    number integer DEFAULT 0 NOT NULL,
    title text NOT NULL,
    content text,
    score integer,
    id_task integer NOT NULL
);
    DROP TABLE public.questions;
       public         heap    postgres    false            �            1259    84004    tasklist    TABLE     {   CREATE TABLE public.tasklist (
    id integer DEFAULT 0 NOT NULL,
    name text NOT NULL,
    description text NOT NULL
);
    DROP TABLE public.tasklist;
       public         heap    postgres    false            �            1259    84010    users    TABLE       CREATE TABLE public.users (
    id integer DEFAULT 0 NOT NULL,
    lastname text NOT NULL,
    name text NOT NULL,
    midname text,
    login text NOT NULL,
    password text NOT NULL,
    post character varying(100) DEFAULT 'Стажер'::character varying NOT NULL
);
    DROP TABLE public.users;
       public         heap    postgres    false                      0    84051 	   infousers 
   TABLE DATA           5   COPY public.infousers (id_user, id_task) FROM stdin;
    public          postgres    false    217   �                 0    83997 	   questions 
   TABLE DATA           O   COPY public.questions (id, number, title, content, score, id_task) FROM stdin;
    public          postgres    false    214                    0    84004    tasklist 
   TABLE DATA           9   COPY public.tasklist (id, name, description) FROM stdin;
    public          postgres    false    215   -'                 0    84010    users 
   TABLE DATA           S   COPY public.users (id, lastname, name, midname, login, password, post) FROM stdin;
    public          postgres    false    216   E)       v           2606    84017    questions questions_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.questions
    ADD CONSTRAINT questions_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.questions DROP CONSTRAINT questions_pkey;
       public            postgres    false    214            x           2606    84019    tasklist tasklist_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.tasklist
    ADD CONSTRAINT tasklist_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.tasklist DROP CONSTRAINT tasklist_pkey;
       public            postgres    false    215            z           2606    84021    users users_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    216            |           2606    84054     infousers infousers_id_task_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.infousers
    ADD CONSTRAINT infousers_id_task_fkey FOREIGN KEY (id_task) REFERENCES public.questions(id);
 J   ALTER TABLE ONLY public.infousers DROP CONSTRAINT infousers_id_task_fkey;
       public          postgres    false    217    3190    214            }           2606    84059     infousers infousers_id_user_fkey    FK CONSTRAINT        ALTER TABLE ONLY public.infousers
    ADD CONSTRAINT infousers_id_user_fkey FOREIGN KEY (id_user) REFERENCES public.users(id);
 J   ALTER TABLE ONLY public.infousers DROP CONSTRAINT infousers_id_user_fkey;
       public          postgres    false    216    3194    217            {           2606    84032     questions questions_id_task_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.questions
    ADD CONSTRAINT questions_id_task_fkey FOREIGN KEY (id_task) REFERENCES public.tasklist(id);
 J   ALTER TABLE ONLY public.questions DROP CONSTRAINT questions_id_task_fkey;
       public          postgres    false    215    3192    214               ,   x�3�4�2�44F@l� 	.cN�D���=... ��X            x��[�n�]���0� ����r�0��&Yj�Ebp�?`�C�TH��+��)����i����ݿ�/I�Su���H	�����֭ǩSu/otnt�eV������zeV�ʢ�W��g�,��rn?��e�%�wZ�}�;Kʉ�ɧ��<�z�<��iY�?�e���	�㯪�s�SΫ�r�GC�q3)s��,�2z$�af���i�YT�L�WX:�:�#+ϸ����˻/��>�r����3Y�ȣ�jP�u's.�[����<���Sy<��T�D����TrZ�n7�h�:�	3�)��!��O��Sy|�ث|:4@�Y���0%�,�N�e��H��s���2���g;e���B��B*�Hd�.1D�P���F&3�6�Le��iu ����H�Ê�5��
�/��x �ye�3EB:��f3��2���{-���x�ʫ-��ô���>�Π
j��zȷ|
QD;�mӵX���E۶{�jB����)��_R�3L ��e�+ܾ��l��� ���SLDg��0�{�R�mgѳ�|��6�vs�15:��h>����Y91�^R}���ۘUg�=�ѱR�a�\��ľ�[�u�t>V'	nǑ�-5�c��� u@9'mlT��Uqt���V�0�<X�� O��9��Q9��/(�J�=d��P�1��A5�)�&w�? ��@ąLِJq�ko�'�R�������ĉE	@��#45S�I�KD�|q�JԼ���`�B��5�v8D�k3h�!<�q�s��]�ٹ�)O�ySN���s�N�R�j6Mu���У6�=2D=��)�!3�,�k�it���u�SA,A�I�a��x��������l�9���g��}��h>���:�� �9��]�a��k�R���.M7$u��\�l� ��)W��T�:o��Kb�ڒs���8M%��(\{Ge�6r�p�5P~T��w�tg�]���ɠ�o$0�����o�?|��_���q�D7��i��sMg��g��Jvh�tM�!�ށ�@ff�s+�ԅ_! 2g8�_��#,%#:���J/l��q�s��$C����a���u���8N���o$0 �H�\c�J%��:��^`.�Zn1?Q�������1���)�Bϓ(hU�Z�s�x<�$��ɒ�풛>�=�	��|��v��m^	e�[6��I�m���A�0R�)���/���߱ɸ�nf����(��\�cp��e��\� u�$6�j2��T�c2��!�;��.`���T ����!8h �8��dc�H}'�0R+��"ŜmX&�
)�6(bTf�	fY��*Y��.�N^�&�An픣g�z�,�z2��q٢D��g;���}�UmWJ�.;1/��J��s!��v2U%��ԉ�_�1b�y�i��)�Um��gƭk*�܏i\�m�n҃&��I澱�El=��:�b��US� �2cK	Gf��枂J��H~Q�Jդ񶨎A���z���߽�v����J/D��W�����VGe��2|�Ց����i@,qf�B�'��4�?���}f����)?W�(d�(��:���W�\�Ҹ�� �� ��=��&d�	�[MK�j�,�A5"X{;�,�G�������Q �%��?���C�+��[�#mF�����V�
�S>��O�|�9bT�.�yʲ`��l�%����w��p�U���H��9BK�XRX��������A����	ǲU�����F}XC�$�v���{})(���2�>��g*Lh\�H++Ө�̬����(Q�(6Pg�A�u}E��d�׻���~`9�+���A[ĥ��4Q	��*Uj��k��ʾG����Ši�h�q�j�nvm�c[j
�l�7���VH�[�Mg�l��%��C4����B��rj���6�xr�H(��îL �*H������2�X�	�r�i!�b�-����g�� �'X_��B���D��vP����ɧY*����؜KY���V=����"�ZU�3)w�ESÿTcwmw�o>9��,���S��Z#���V�߬�f���C�uj�����x�M�ݭ�"�"TcN�)���bf>��P��sV�Iq[��)Dp���\-dӻ� g��򆈴�GVH�JO�\٨��mƉ8�'��2w�Uk"�!��4++C9H��v&���(����F�H�j��z1Dg��c��O_��5?pĬ��,���$|-�b��_�5PY�kBg^�:�}Ǐ�B�/{jL���Tu�|f��/jl�X��� ��+��E\�N6�D�`unEs 
����"�E&3���b�ȸ��OMU{��zs�{�u̱��!7d��r�N�i��5��'g�s>G�N��kMy��a��l0�G��U�q�k�z|���lXd��9a���M�gl?��A��l��v������u�K�;��#�u���Uy���¦=UX�v8$��P2�d�ҟX����e�W&���h�6�5��ޖ�2N�ؚ3���J%&��K$��f���ZG^�R��>o}���WA,�e(��ep"u�K�r[|.�?��Ϝe�V�oK+Z��|�:&�[H������U8J'֐H���=�SF*4��}ڳ�f$XoH޽�������R�@�q�ܶ�^��9����q�Y���Ti*#����PBC|ܘL�������b	?�������,���+�u(�I3����H��I++ǝ�5�}TkɁ`ą������VÉ�F�"iB��zt��M���p��e��R^4G ��!_�Ws�>�G�A��L>~X�X��?,�B��$E�m���b˴��@keūK[��ѱ��Nq�_��3vVG�v���R+y<�T?9�I%�$���h��-�i=��[+�.��{x"��}��Ic\�Dv8�q�j#Q{]��=�{���@c��-�6B{�~ѷVC���S�i|��`���v�5�-�R4��w~˸��쐡����D-�el�0��&v���F�[;<�*y�p�;BF%]ԉS��kV�ܥ��.÷Q\Q��Lvz]vP�N^?Թ��zvo`��_�b�f�Mv���,���٪50���c����.�kec�C��SÙA]�tlQym�;�j�C�j�Ho��
�Mv&j�T�(<�ڴ�>����FM��.x�g���uR����슜���'�ms�����r�ɘ축ʐ�et�h�]��,��2k�i��Y��!�����ɂ�vCo��ĵt�w��$yp���6�>�/�O�W[\�1�ڵ^�uʟkW����u�8�_M>�럾��7QC�4>%�!�L?i�tQ�g�|��WN�����ǈ��[�b������S���@}�7T��n�n�jW�aT@���34���j6��y�b�|�m�������/㎗P<�2�[ԁܩ�ԽI�p�3��veI��j�	�쵨�Y�\�~U�X�I�ܽ�K�b�"p�ka?ckp��@�2��۝��R��I�TF�g<A�E5�lQr�QK��ג�+�Ս��a��kw�]_�q:�<⤁�D��↲+���7n\��Vu/`��-Ygnh�.<�n��خ�����x�b�4�S��ƶe�(���6��%��1��_F���V�'��4Sb.z䡂�khi�����_�+=#��`���#㨀�����4�W&��\*V�A��d����8�J�4F��zO�[�b2s��f�Lssh<9������ (j0装%�+�½RGk9~��rSu�R6��b�)]b��&��t�A\��=z��)�顃�q��(�V�I���~��aT~7RM�N�����g���P	�Sq���ݲ��1O^lF�3�:`���,>f���i!��]��|L&��<� �����6�|�&��TR���Dp���"O��šX�|�&�T�c
O:)����.���������JƟȸ'��m�=^ab�V:ďO��Έ	�Yˇ2��`��%��ؗ"������z����D���D'��Pf.�z����3x�������L�Q�6��y�v����8�Ì��R^u��4�.ۺ�b�^t�(GP��y����a鏆až���|L(��g�   ���p�Ei�Ϊ|pxJ\��D`"�^��5�-G?��q�e�Q�3�ܓX�09�j��JCkP��}�l���6u묗�,�Չ"�k�iC�\wT���Q'y;�mZ���kiy�?ֶ��d㈶�䅒���C�o���n��7
���	V_btT��c+~����"�%��I� �Er��'�Bt�輸ya�Sp~G�`���:��L1���c����ӄ"Q��܁mRрg�|��8�v(@��v��%��U��y�$���ܨRrw=,�㥻9�Z���9��FN�չ��n-����� ք�K�YZ*R��Ν8�j8�r���T��W�o�8ަ�i��;"F�:3�*tSO�����2���ok��,
��qR�J3��ܮ���#t����J�6r�w�SCQ���혹x���=�u��?�̽��Qblv�G�l&�t��	��*v>��DYO nCǕ�����Q<�jH���g�h��8K70G��e�T/��p3����?XM�na��w5;D�"Bk�@k����X��d��~���!�}�R��2�m��짳�4~?k�7�[��qB����4Оf��f�ڦ-���W���V*��h�O_��ʮ%�U�m� W=8a엶\L��<>8���M>�[�����;�{���*����؇Gm1�l�|�|��� ����dc$+)"�����/��ٕ�'��GBJ�T�2�/�2�#��b����?%dL�#���b������Y׋��!|ڹ)�r����ʿ�lm�           x��T�N�@���>�D<jzJ>�!�
=B����N.����1�w$&�P��^���̎��ț�a$�x�d�d&�,e#�L� ���F���K�d*92�̬Q�9i-�Hi<md�+s��:��!6Fnk����F�À����.�&L�<�^� ۄ!�kt�ҡ#p"4�8���?�6�Ԍ��F�q��Ie�jз)�=1�F��;�]&4Ίh�*y̵@��m�$���չC%�������B�&����I��6�*+�L��5�H�**�Ⴑ*-�5��}�;��h�O~�<)�;�}{ڱ&m��0(�p�~l����!uؗ��L_��Wp+0���krG^���x��i�|�����tT�9GN-���ZQ�p�&'krfG/N�U2Ƞk�nW��1��<^Wqy�K/�Z�{c�J����gF^ɱ�줒~�{Q6�:�"ͺ�k�y$�LMN����V.��;���' %��d��b�=����ޑaUC�{h�I���y4���뾵��L         �   x�u�=�P���N�4A�`a�L����[�����ؚx @��a�F?�X�l2�3߬�pC�%*$���"�@m7����X�.>//��H�JQH(�9*��k){<�z�%��ᖮ���;�Y���X�Ex73F%>Qr�5Wd�Dx���x��[�}���M狶��$J:L=����Z��W�     