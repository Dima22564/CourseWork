<template>
  <div class="q-pa-lg" style="min-width: 500px">

    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
    >
      <q-input
        filled
        v-model="name"
        label="Название"
        hint="Название"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="desc"
        label="Описание"
        hint="Описание"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнени']"
      />

      <q-input
        filled
        v-model="includeAt"
        hint="Действительна с даты"
        dense
        type="date"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнени']"
      />

      <div>
        <q-btn label="Создать" type="submit" color="primary"/>
        <q-btn label="Сбросить" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>

  </div>
</template>

<script>
import moment from 'moment'
export default {
  data: () => {
    return {
      name: null,
      desc: null,
      includeAt: moment().format('YYYY-MM-DD')
    }
  },
  methods: {
    async onSubmit () {
      try {
        const form = new FormData()
        form.append('Name', this.name)
        form.append('Description', this.desc)
        form.append('IncludeAt', this.includeAt)

        const result = await this.$store.dispatch('position/create', form)

        if (result.status === 201) {
          this.$q.notify({
            type: 'positive',
            message: 'Должность добавлена успешно'
          })
        }
      } catch (e) {
        this.$q.notify({
          type: 'negative',
          message: e.response.data.message
        })
      } finally {
        this.loading = false
      }
    },
    onReset () {
      this.name = null
      this.desc = null
      this.includeAt = moment().format('YYYY-MM-DD')
    }
  }
}
</script>
